namespace Test
{
    internal interface IHasInitialState<TSelf, TState> : ICaptureSelf<TSelf>
        where TState : struct
    {
    }
}

