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
    }
}
