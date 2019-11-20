using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        public static void Main()
        {
            Item item = default;

            var a = item
                .MoveToInitialState()
                .MoveToState( default( ItemStateTransition ) )
                .MoveToState( default( ItemStateTerminal ) );

            Console.WriteLine( a.State );

            var b = item
                .MoveToInitialState()
                .MoveToState( default( ItemStateTerminal ) );

            Console.WriteLine( b.State );
        }
    }
}

