using NUnit.Framework;
using CannonAttack;
using System;
using NUnit.Framework.Constraints;

namespace CannonAttack.Tests
{
    [TestFixture]
    public class CannonShotAttemptPropertyTests
    {
        [Test]
        public void Given_AnAngle_When_SettingTheAngle_Then_AngleShouldBeSet()
        {
            var angle = 45;
            var speed = 100;

            var attempt = new CannonShotAttempt(angle, speed);

            Assert.AreEqual(angle, attempt.Angle);
        }

        [Test]
        public void Given_AnAngleLessThan1Degree_When_SettingTheAngle_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var angle = 0;
            var speed = 100;

            void testDelegate() => new CannonShotAttempt(angle, speed);

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_AnAngleGreaterThan89Degrees_When_SettingTheAngle_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var angle = 90;
            var speed = 100;

            void testDelegate() => new CannonShotAttempt(angle, speed);

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ASpeed_When_SettingTheSpeed_Then_SpeedShouldBeSet()
        {
            var speed = 100;
            var angle = 15;

            var attempt = new CannonShotAttempt(angle, speed);

            Assert.AreEqual(speed, attempt.Speed);
        }

        [Test]
        public void Given_ASpeedLessThanOrEqualTo0_When_SettingTheSpeed_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var speed = 0;
            var angle = 15;

            void testDelegate() => new CannonShotAttempt(angle, speed);

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ASpeedGreaterThanC_When_SettingTheSpeed_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var speed = 2.99791e10;
            var angle = 15;

            void testDelegate() => new CannonShotAttempt(angle, speed);

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }
    }
}
