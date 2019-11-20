namespace Test
{
    internal interface IInState<TSelf, TState> : ICaptureSelf<TSelf>
        where TState : struct
    {
        TState State { get; }
    }
}

