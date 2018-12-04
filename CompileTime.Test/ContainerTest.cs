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
    }
}
