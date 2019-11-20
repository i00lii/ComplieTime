namespace Test
{
    internal interface ICaptureSelf<TSelf>
    {
        TSelf Self { get; }
    }
}

