using System;
using System.Collections.Generic;

namespace CompileTime
{
    public struct TransformContainer<TInput, TOutput, TContainer> : IEquatable<TransformContainer<TInput, TOutput, TContainer>>
        where TContainer : struct, IContainer<TInput>
    {
        public Func<TInput, TOutput> Transform { get; }
        public TContainer Container { get; }
        public TransformContainer( TContainer container, Func<TInput, TOutput> transform ) => (Container, Transform) = (container, transform);

        public override bool Equals( object obj ) => obj is TransformContainer<TInput, TOutput, TContainer> && Equals( (TransformContainer<TInput, TOutput, TContainer>)obj );
        public bool Equals( TransformContainer<TInput, TOutput, TContainer> other ) => EqualityComparer<Func<TInput, TOutput>>.Default.Equals( Transform, other.Transform ) && EqualityComparer<TContainer>.Default.Equals( Container, other.Container );
        public override int GetHashCode() => HashCode.Combine( Transform, Container );

        public static bool operator ==( TransformContainer<TInput, TOutput, TContainer> container1, TransformContainer<TInput, TOutput, TContainer> container2 ) => container1.Equals( container2 );
        public static bool operator !=( TransformContainer<TInput, TOutput, TContainer> container1, TransformContainer<TInput, TOutput, TContainer> container2 ) => !(container1 == container2);
    }
}
