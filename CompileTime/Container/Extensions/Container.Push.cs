namespace CompileTime
{
    public static partial class Container
    {
        public static Container<T, TContainer> Push<T, TContainer>( this TContainer innerContainer, T value )
           where TContainer : struct, IContainer<T>
           => new Container<T, TContainer>( value, innerContainer );
    }
}
