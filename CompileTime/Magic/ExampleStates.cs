namespace Test
{
    internal readonly struct TransitionAState :
        IPossibleInitialState<TransitionAState>,
        IPossibleTransitionFrom<TransitionBState, TransitionAState>
    {
    }

    internal readonly struct TransitionBState :
        IPossibleInitialState<TransitionBState>,
        IPossibleTransitionFrom<TransitionAState, TransitionBState>
    {
    }
}

