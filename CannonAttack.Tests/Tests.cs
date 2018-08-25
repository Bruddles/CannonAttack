using NUnit.Framework;
using CannonAttack;
using System;
using NUnit.Framework.Constraints;

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
            var angle = 45;

            cannon.Angle = angle;

            Assert.AreEqual(angle, cannon.Angle);
        }


        [Test]
        public void Given_AnAngleLessThan1Degree_When_SettingTheAngle_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = new Cannon();
            var angle = 0;

            void testDelegate() => cannon.Angle = angle;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_AnAngleGreaterThan89Degrees_When_SettingTheAngle_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = new Cannon();
            var angle = 90;

            void testDelegate() => cannon.Angle = angle;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }
        
        [Test]
        public void Given_ASpeed_When_SettingTheSpeed_Then_SpeedShouldBeSet()
        {
            var cannon = new Cannon();
            var speed = 100;

            cannon.Speed = speed;

            Assert.AreEqual(speed, cannon.Speed);
        }

        [Test]
        public void Given_ASpeedLessThanOrEqualTo0_When_SettingTheSpeed_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = new Cannon();
            var speed = 0;

            void testDelegate() => cannon.Speed = speed;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ASpeedGreaterThanC_When_SettingTheSpeed_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = new Cannon();
            var speed = 2.99791e10;

            void testDelegate() => cannon.Speed = speed;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ANewCannon_When_DoingNothing_Then_TargetDistancesShouldHaveBeenSet()
        {
            var cannon = new Cannon();
            
            Assert.IsNotNull(cannon.TargetDistance);
        }

        [Test]
        public void Given_TwoCannons_When_DoingNothing_Then_TargetDistancesShouldBeRandom()
        {
            var cannon = new Cannon();
            var cannon2 = new Cannon();

            Assert.AreNotEqual(cannon.TargetDistance, cannon2.TargetDistance);
        }

        [Test]
        public void Given_ATargetDistance_When_SettingTheTargetDistance_Then_TargetDistanceShouldBeSet()
        {
            var cannon = new Cannon();
            var distance = 100;

            cannon.TargetDistance = distance;

            Assert.AreEqual(distance, cannon.TargetDistance);
        }

        [Test]
        public void Given_ATargetDistanceLessThan0_When_SettingTheTargetDistance_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = new Cannon();
            double distance = -1000;

            void testDelegate() => cannon.TargetDistance = distance;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ASpeedGreaterThan20000m_When_SettingTheTargetDistance_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = new Cannon();
            var distance = 20001;

            void testDelegate() => cannon.TargetDistance = distance;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }
    }
}
