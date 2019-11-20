using System;

namespace Test
{
    internal static class Extensions
    {
        public static IInState<TSelf, TState> MoveToInitialState<TSelf, TState>
        (
            this IHasInitialState<TSelf, TState> self
        )
            where TState : struct
            => new Capture<TSelf, TState>( self.Self, default );

        public static IInState<TSelf, TOutputState> MoveToState<TSelf, TInputState, TOutputState>
        (
            this IInState<TSelf, TInputState> self,
            TOutputState state
        )
            where TInputState : struct
            where TOutputState : struct
            where TSelf : IMayTransferTo<TSelf, TInputState, TOutputState>
            => new Capture<TSelf, TOutputState>( self.Self, state );

        private class Capture<TSelf, TState> : IInState<TSelf, TState>
            where TState : struct
        {
            public TState State { get; }
            public TSelf Self { get; }

            public Capture( TSelf self, TState state ) => (Self, State) = (self, state);
        }
    }
}

