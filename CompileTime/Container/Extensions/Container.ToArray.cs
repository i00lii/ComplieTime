using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CompileTime
{
    public static partial class Container
    {
        public static T[] ToArray<T, TContainer>( this Container<T, TContainer> container )
            where TContainer : struct, IContainer<T>
            => ArrayConverter<T, Container<T, TContainer>>.Convert( container );

        private static class ArrayConverter<T, TContainer>
            where TContainer : struct, IContainer<T>
        {
            public static Func<TContainer, T[]> Convert { get; } = CreateConverter();

            private static Func<TContainer, T[]> CreateConverter()
            {
                ParameterExpression param = Expression.Parameter( typeof( TContainer ) );

                return Expression
                    .Lambda<Func<TContainer, T[]>>
                    (
                       Expression.NewArrayInit( typeof( T ), EnumerateValues() ),
                       param
                    )
                    .Compile();

                IEnumerable<Expression> EnumerateValues()
                {
                    Type containerType = typeof( TContainer );
                    Expression containerVariable = param;

                    while (containerVariable.Type != typeof( EmptyContainer<T> ))
                    {
                        MemberExpression containerValue = Expression.Property( containerVariable, _variable );
                        containerVariable = Expression.Property( containerVariable, _innerContainer );
                        yield return containerValue;
                    }
                }
            }
        }
    }
}
