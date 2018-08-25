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

        [Test]
        public void Given_AnAngle_When_SettingTheAngle_Then_AngleShouldBeSet()
        {
            var cannon = new Cannon();
            var angle = 0;

            cannon.Angle = angle;

            Assert.AreEqual(angle, cannon.Angle);
        }

        [Test]
        public void Given_ASpeed_When_SettingTheSpeed_Then_SpeedShouldBeSet()
        {
            var cannon = new Cannon();
            var speed = 0;

            cannon.Speed = speed;

            Assert.AreEqual(speed, cannon.Speed);
        }
    }
}
