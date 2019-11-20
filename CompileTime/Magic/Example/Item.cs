namespace Test
{
    internal readonly struct Item :
        IHasInitialState<Item, ItemStateInitial>,

        IMayTransferTo<Item, ItemStateInitial, ItemStateTransition>,
        IMayTransferTo<Item, ItemStateInitial, ItemStateTerminal>,
        IMayTransferTo<Item, ItemStateTransition, ItemStateTerminal>
    {
        public Item Self => this;
    }
}

