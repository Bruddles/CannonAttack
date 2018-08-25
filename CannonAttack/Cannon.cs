using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack
{
    public class Cannon
    {
        public const string DEFAULT_ID = "HUMAN";
        public const double MAX_DISTANCE = 20000;
        public const double G = 9.81;
        
        private double _targetDistance;

        private static Cannon _instance;

        public string Id { get; set; }

        public double TargetDistance
        {
            get => _targetDistance;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Distance cannot be les than 0m.");
                if (value > MAX_DISTANCE)
                    throw new ArgumentOutOfRangeException("Distance cannot be greater than 20000m.");
                _targetDistance = value;
            }
        }

        private Cannon()
        {
            Id = DEFAULT_ID;
            TargetDistance = new Random().NextDouble() * MAX_DISTANCE;
        }

        public static Cannon GetInstance()
        {
            if (_instance == null)
                _instance = new Cannon();

            return _instance;
        }

        public bool Shoot(CannonShotAttempt attempt)
        {
            var shotDistance = CalculateShotDistance(attempt);

            if (shotDistance >= TargetDistance + 50 || shotDistance <= TargetDistance - 50)
                return false;

            return true;
        }

        private double CalculateShotDistance(CannonShotAttempt attempt)
        {
            var angleRadians = ConvertToRadians(attempt.Angle);
            return (2 * Math.Pow(attempt.Speed, 2) * Math.Sin(angleRadians) * Math.Cos(angleRadians)) / G;
        }

        private double ConvertToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

    }
}
