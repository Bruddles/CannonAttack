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

        [Test]
        public void Given_APreviouslyUsedCannon_When_Resetting_Then_ThecannonShouldBeReset()
        {
            var cannon = Cannon.GetInstance();
            var distance = 1000;

            cannon.TargetDistance = distance;

            var attempt = new CannonShotAttempt(45, 1);
            var result = cannon.Shoot(attempt);

            var attemptCount = cannon.PreviousShotResults.Count;

            cannon.Reset();

            Assert.AreNotEqual(distance, cannon.TargetDistance);
            Assert.AreNotEqual(attemptCount, cannon.PreviousShotResults.Count);
        }

        [Test]
        public void Given_MultipleMissedShots_When_Shooting_Then_ThePreviousAttemptsShouldMatch()
        {
            var cannon = Cannon.GetInstance();
            cannon.Reset();

            cannon.TargetDistance = 1000;

            var attempt = new CannonShotAttempt(45, 1);

            cannon.Shoot(attempt);
            cannon.Shoot(attempt);

            attempt = new CannonShotAttempt(45, 100);

            var result = cannon.Shoot(attempt);

            Assert.IsTrue(result.Hit);
            Assert.AreEqual(3, cannon.PreviousShotResults.Count);
        }
    }
}
