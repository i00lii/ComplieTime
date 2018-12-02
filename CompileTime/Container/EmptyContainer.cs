namespace CompileTime
{
    public static class EmptyContainer
    {
        public static Container<T, EmptyContainer<T>> Push<T>( T value ) => new Container<T, EmptyContainer<T>>( value, default );
    }

    public readonly struct EmptyContainer<T> : IContainer<T>
    {
    }
}
