using NUnit.Framework;
using CannonAttack;
using System;

namespace CannonAttack.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Given_Anything_When_Always_Then_IDShouldEqualHuman()
        {
            Assert.AreEqual("HUMAN", Cannon.ID);
        }
    }
}
