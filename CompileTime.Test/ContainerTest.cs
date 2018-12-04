﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompileTime.Test
{
    [TestFixture]
    public class ContainerTest
    {
        [Test]
        public void PushTest()
            => EmptyContainer
            .Push( 42 )
            .Should().Be( new Container<int, EmptyContainer<int>>( 42, default ) );

        [Test]
        public void PopTest()
        {
            int popped = 0;
            EmptyContainer
                .Push( 42 ).Push( 43 )
                .Pop( item => popped = item )
                .Should().Be( new Container<int, EmptyContainer<int>>( 42, default ) );

            popped.Should().Be( 43 );
        }

        [Test]
        public void ReverseTest()
            => EmptyContainer
            .Push( 2 ).Push( 1 ).Push( 0 )
            .Reverse()
            .Should()
            .Be( EmptyContainer.Push( 0 ).Push( 1 ).Push( 2 ) );
    }
}
