using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack
{
    public class CannonShotResult
    {
        public const double G = 9.81;

        public readonly CannonShotAttempt Attempt;
        public readonly double TargetDistance;
        public readonly double ShotDistance;
        public readonly bool Hit;

        public CannonShotResult( CannonShotAttempt attempt, double targetDistance)
        {
            Attempt = attempt;
            TargetDistance = targetDistance;
            ShotDistance = CalculateShotDistance();
            Hit = !(ShotDistance >= TargetDistance + 50 || ShotDistance <= TargetDistance - 50);
        }

        private double CalculateShotDistance()
        {
            var angleRadians = ConvertToRadians(Attempt.Angle);
            return (2 * Math.Pow(Attempt.Speed, 2) * Math.Sin(angleRadians) * Math.Cos(angleRadians)) / G;
        }

        private double ConvertToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
}
