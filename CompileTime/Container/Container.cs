using System;
using System.Collections.Generic;

namespace CompileTime
{
    public readonly struct Container<T, TInnerContainer> : IContainer<T>, IEquatable<Container<T, TInnerContainer>>
       where TInnerContainer : struct, IContainer<T>
    {
        public T Value { get; }
        public TInnerContainer InnerContainer { get; }
        public Container( T value, TInnerContainer innerContainer ) => (Value, InnerContainer) = (value, innerContainer);

        public override bool Equals( object obj ) => obj is Container<T, TInnerContainer> && Equals( (Container<T, TInnerContainer>)obj );
        public bool Equals( Container<T, TInnerContainer> other ) => EqualityComparer<T>.Default.Equals( Value, other.Value ) && EqualityComparer<TInnerContainer>.Default.Equals( InnerContainer, other.InnerContainer );
        public override int GetHashCode() => HashCode.Combine( Value, InnerContainer );

        public static bool operator ==( Container<T, TInnerContainer> container1, Container<T, TInnerContainer> container2 ) => container1.Equals( container2 );
        public static bool operator !=( Container<T, TInnerContainer> container1, Container<T, TInnerContainer> container2 ) => !(container1 == container2);
    }
}

