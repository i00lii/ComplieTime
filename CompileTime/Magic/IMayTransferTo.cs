namespace Test
{
    internal interface IMayTransferTo<TSelf, TInputState, TOutputState>
        where TInputState : struct
        where TOutputState : struct
    {
    }
}

