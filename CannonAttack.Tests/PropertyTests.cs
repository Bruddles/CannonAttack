using NUnit.Framework;
using CannonAttack;
using System;
using NUnit.Framework.Constraints;

namespace CannonAttack.Tests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void Given_ACannon_When_InitialisedAndNotUpdated_Then_IDShouldEqualDefault()
        {
            var cannon = Cannon.GetInstance();

            Assert.AreEqual(Cannon.DEFAULT_ID, cannon.Id);
        }

        [Test]
        public void Given_ACannon_When_CallingGetIsntanceASecondTime_Then_TheyShouldBeTheSame()
        {
            var cannon = Cannon.GetInstance();
            var cannon2 = Cannon.GetInstance();

            Assert.AreSame(cannon, cannon2);
        }

        [Test]
        public void Given_AnAngle_When_SettingTheAngle_Then_AngleShouldBeSet()
        {
            var cannon = Cannon.GetInstance();
            var angle = 45;

            cannon.Angle = angle;

            Assert.AreEqual(angle, cannon.Angle);
        }


        [Test]
        public void Given_AnAngleLessThan1Degree_When_SettingTheAngle_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = Cannon.GetInstance();
            var angle = 0;

            void testDelegate() => cannon.Angle = angle;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_AnAngleGreaterThan89Degrees_When_SettingTheAngle_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = Cannon.GetInstance();
            var angle = 90;

            void testDelegate() => cannon.Angle = angle;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }
        
        [Test]
        public void Given_ASpeed_When_SettingTheSpeed_Then_SpeedShouldBeSet()
        {
            var cannon = Cannon.GetInstance();
            var speed = 100;

            cannon.Speed = speed;

            Assert.AreEqual(speed, cannon.Speed);
        }

        [Test]
        public void Given_ASpeedLessThanOrEqualTo0_When_SettingTheSpeed_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = Cannon.GetInstance();
            var speed = 0;

            void testDelegate() => cannon.Speed = speed;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ASpeedGreaterThanC_When_SettingTheSpeed_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = Cannon.GetInstance();
            var speed = 2.99791e10;

            void testDelegate() => cannon.Speed = speed;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ANewCannon_When_DoingNothing_Then_TargetDistancesShouldHaveBeenSet()
        {
            var cannon = Cannon.GetInstance();
            
            Assert.IsNotNull(cannon.TargetDistance);
        }
        
        [Test]
        public void Given_ATargetDistance_When_SettingTheTargetDistance_Then_TargetDistanceShouldBeSet()
        {
            var cannon = Cannon.GetInstance();
            var distance = 100;

            cannon.TargetDistance = distance;

            Assert.AreEqual(distance, cannon.TargetDistance);
        }

        [Test]
        public void Given_ATargetDistanceLessThan0_When_SettingTheTargetDistance_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = Cannon.GetInstance();
            double distance = -1000;

            void testDelegate() => cannon.TargetDistance = distance;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ASpeedGreaterThan20000m_When_SettingTheTargetDistance_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var cannon = Cannon.GetInstance();
            var distance = 20001;

            void testDelegate() => cannon.TargetDistance = distance;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }
    }
}
