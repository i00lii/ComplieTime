using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CompileTime
{
    public static partial class Container
    {
        private const string _innerContainer = nameof( Container<bool, EmptyContainer<bool>>.InnerContainer );
        private const string _variable = nameof( Container<bool, EmptyContainer<bool>>.Value );

        public static Container<T, TContainer> Reverse<T, TContainer>( this Container<T, TContainer> container )
           where TContainer : struct, IContainer<T>
           => ReverseConverter<T, Container<T, TContainer>>.Convert( container );

        private static Container<T, TContainer> Create<T, TContainer>( TContainer container, T value )
           where TContainer : struct, IContainer<T>
           => new Container<T, TContainer>( value, container );

        private static class ReverseConverter<T, TContainer>
           where TContainer : struct, IContainer<T>
        {
            private static readonly MethodInfo _genericCreateMethod = typeof( Container ).GetMethod( nameof( Container.Create ), BindingFlags.NonPublic | BindingFlags.Static );

            public static Func<TContainer, TContainer> Convert { get; } = CreateConverter();

            private static Func<TContainer, TContainer> CreateConverter()
            {
                List<ParameterExpression> locals = new List<ParameterExpression>();
                List<Expression> body = new List<Expression>();

                ParameterExpression containerVariable = Expression.Variable( typeof( TContainer ) );
                ParameterExpression resultVariable = Expression.Variable( typeof( EmptyContainer<T> ) );
                Expression resultAssignment = Expression.Assign( resultVariable, Expression.Default( typeof( EmptyContainer<T> ) ) );

                locals.Add( containerVariable );
                locals.Add( resultVariable );

                body.Add( resultAssignment );

                while (containerVariable.Type != typeof( EmptyContainer<T> ))
                {
                    ParameterExpression oldResult = locals[locals.Count - 1];
                    ParameterExpression oldContainer = locals[locals.Count - 2];

                    Type[] containerGeneric = oldContainer.Type.GetGenericArguments();

                    containerVariable = Expression.Variable( containerGeneric[1] );
                    Expression containerAssignment = Expression.Assign( containerVariable, Expression.Property( oldContainer, _innerContainer ) );

                    resultVariable = Expression.Variable( typeof( Container<,> ).MakeGenericType( containerGeneric[0], oldResult.Type ) );
                    resultAssignment = Expression.Assign
                    (
                       resultVariable,
                       Expression.Call
                       (
                          _genericCreateMethod.MakeGenericMethod( containerGeneric[0], oldResult.Type ),
                          oldResult,
                          Expression.Property( oldContainer, _variable )
                       )
                    );

                    locals.Add( containerVariable );
                    locals.Add( resultVariable );

                    body.Add( containerAssignment );
                    body.Add( resultAssignment );
                }

                return Expression
                   .Lambda<Func<TContainer, TContainer>>
                   (
                      Expression.Block( typeof( TContainer ), locals.Skip( 1 ), body ),
                      locals[0]
                   )
                   .Compile();
            }
        }
    }
}

