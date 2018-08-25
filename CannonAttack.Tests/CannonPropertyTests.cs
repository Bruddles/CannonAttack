using NUnit.Framework;
using CannonAttack;
using System;
using NUnit.Framework.Constraints;

namespace CannonAttack.Tests
{
    [TestFixture]
    public class CannonPropertyTests
    {
        public Cannon TestCannon;

        [SetUp]
        public void Init()
        {
            TestCannon = Cannon.GetInstance();
        }

        [Test]
        public void Given_ACannon_When_InitialisedAndNotUpdated_Then_IDShouldEqualDefault()
        {
            Assert.AreEqual(Cannon.DEFAULT_ID, TestCannon.Id);
        }

        [Test]
        public void Given_ACannon_When_CallingGetIsntanceASecondTime_Then_TheyShouldBeTheSame()
        {            var cannon2 = Cannon.GetInstance();

            Assert.AreSame(TestCannon, cannon2);
        }
        
        [Test]
        public void Given_ANewCannon_When_DoingNothing_Then_TargetDistancesShouldHaveBeenSet()
        {
            Assert.IsNotNull(TestCannon.TargetDistance);
        }

        [Test]
        public void Given_ATargetDistance_When_SettingTheTargetDistance_Then_TargetDistanceShouldBeSet()
        {
            var distance = 100;

            TestCannon.TargetDistance = distance;

            Assert.AreEqual(distance, TestCannon.TargetDistance);
        }

        [Test]
        public void Given_ATargetDistanceLessThan0_When_SettingTheTargetDistance_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            double distance = -1000;

            void testDelegate() => TestCannon.TargetDistance = distance;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void Given_ATargetDistanceGreaterThan20000m_When_SettingTheTargetDistance_Then_ArgumentOutOfRangeExceptionShouldBeThrown()
        {
            var distance = 20001;

            void testDelegate() => TestCannon.TargetDistance = distance;

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }
    }
}
