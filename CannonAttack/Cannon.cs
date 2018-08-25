using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack
{
    public class Cannon
    {
        // Speed of Light in a Vacuum. Units m/sec 
        public const double LIGHTSPEED = 2.9979e8;
        public const string DEFAULT_ID = "HUMAN";
        public const double MIN_ANGLE = 1;
        public const double MAX_ANGLE = 89;
        public const double MAX_DISTANCE = 20000;

        private double _angle;
        private double _speed;
        private double _targetDistance;

        private static Cannon _instance;

        public string Id { get; set; }

        public double Angle
        {
            get => _angle;
            set
            {
                if (value < MIN_ANGLE)
                    throw new ArgumentOutOfRangeException("Angle cannot be less than 1 degree.");
                if (value > MAX_ANGLE)
                    throw new ArgumentOutOfRangeException("Angle cannot be 90 degrees or larger.");
                _angle = value;
            }
        }

        public double Speed
        {
            get => _speed;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Speed cannot be less than or equal to 0m/s.");
                if (value > LIGHTSPEED)
                    throw new ArgumentOutOfRangeException("Speed cannot be greater than the speed of light.");
                _speed = value;
            }
        }

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

    }
}
