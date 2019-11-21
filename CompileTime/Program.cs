using System;

namespace Test
{
    internal readonly struct BadState { }

    public class Program
    {
        public static void Main()
        {
            var initial = Context.Inilialize<TransitionBState>();

            Console.WriteLine( initial.State );

            var transition = initial
                .Move.To<TransitionAState>();

            Console.WriteLine( transition.State );
        }
    }
}

