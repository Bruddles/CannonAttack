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

            var hit = cannon.Shoot(attempt);

            Assert.IsFalse(hit);
        }

        [Test]
        public void Given_ASetupCannonThatShouldHitTheTarget_When_Shooting_Then_TheShotShouldHit()
        {
            var cannon = Cannon.GetInstance();

            cannon.TargetDistance = 1000;

            var attempt = new CannonShotAttempt(45, 100);

            var hit = cannon.Shoot(attempt);

            Assert.IsTrue(hit);
        }
    }
}
