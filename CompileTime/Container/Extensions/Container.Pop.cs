using System;

namespace CompileTime
{
    public static partial class Container
    {
        public static TContainer Pop<T, TContainer>( this Container<T, TContainer> container, Action<T> lambda )
           where TContainer : struct, IContainer<T>
        {
            lambda( container.Value );
            return container.InnerContainer;
        }

        public static TransformContainer<TInput, TOutput, TContainer> Pop<TInput, TOutput, TContainer>( this TransformContainer<TInput, TOutput, Container<TInput, TContainer>> container, Action<TOutput> lambda )
            where TContainer : struct, IContainer<TInput>
        {
            lambda( container.Transform( container.Container.Value ) );
            return new TransformContainer<TInput, TOutput, TContainer>( container.Container.InnerContainer, container.Transform );
        }
    }
}
