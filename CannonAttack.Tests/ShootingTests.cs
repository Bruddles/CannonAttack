using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack.Tests
{
    [TestFixture]
    class ShootingTests
    {
        [Test]
        public void Given_ASetupCannonThatShouldMissTheTarget_When_Shooting_Then_TheShotShouldMiss()
        {
            var cannon = Cannon.GetInstance();

            cannon.TargetDistance = 1000;

            var attempt = new CannonShotAttempt(45, 1);

            var result = cannon.Shoot(attempt);

            Assert.IsFalse(result.Hit);
            Assert.AreEqual(attempt, result.Attempt);
            Assert.AreEqual(cannon.TargetDistance, result.TargetDistance);
        }

        [Test]
        public void Given_ASetupCannonThatShouldHitTheTarget_When_Shooting_Then_TheShotShouldHit()
        {
            var cannon = Cannon.GetInstance();

            cannon.TargetDistance = 1000;

            var attempt = new CannonShotAttempt(45, 100);

            var result = cannon.Shoot(attempt);

            Assert.IsTrue(result.Hit);
            Assert.AreEqual(attempt, result.Attempt);
            Assert.AreEqual(cannon.TargetDistance, result.TargetDistance);
        }
    }
}
