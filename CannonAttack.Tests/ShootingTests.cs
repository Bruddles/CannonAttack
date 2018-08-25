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
            cannon.Angle = 45;
            cannon.Speed = 1;

            var hit = cannon.Shoot();

            Assert.IsFalse(hit);
        }

        [Test]
        public void Given_ASetupCannonThatShouldHitTheTarget_When_Shooting_Then_TheShotShouldHit()
        {
            var cannon = Cannon.GetInstance();

            cannon.TargetDistance = 1000;
            cannon.Angle = 45;
            cannon.Speed = 100;

            var hit = cannon.Shoot();

            Assert.IsTrue(hit);
        }
    }
}
