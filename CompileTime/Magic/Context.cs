namespace Test
{
    internal interface IInState<TState>
    {
        public Context<TState> Move => new Context<TState>();
        public TState State => default;
    }

    internal interface IPossibleInitialState<TInitialState>
        where TInitialState : IPossibleInitialState<TInitialState>
    {
    }

    internal interface IPossibleTransitionFrom<TInputState, TOutputState>
        where TOutputState : IPossibleTransitionFrom<TInputState, TOutputState>
    {
    }

    internal static class Context
    {
        public static IInState<TInitialState> Inilialize<TInitialState>()
            where TInitialState : struct, IPossibleInitialState<TInitialState>
            => new Context<TInitialState>();
    }

    internal class Context<TInputState> : IInState<TInputState>
    {
        public IInState<TOutputState> To<TOutputState>()
            where TOutputState : struct, IPossibleTransitionFrom<TInputState, TOutputState>
            => new Context<TOutputState>();
    }
}
