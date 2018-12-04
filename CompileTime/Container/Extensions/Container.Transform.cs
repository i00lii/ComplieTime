using System;
using System.Collections.Generic;
using System.Text;

namespace CompileTime
{
    public static partial class Container
    {
        public static TransformContainer<TInput, TOutput, Container<TInput, TContainer>> Transform<TInput, TOutput, TContainer>( this Container<TInput, TContainer> container, Func<TInput, TOutput> transform )
            where TContainer : struct, IContainer<TInput>
            => new TransformContainer<TInput, TOutput, Container<TInput, TContainer>>( container, transform );
    }
}
