using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack
{
    public class Cannon
    {
        // Speed of Light in a Vacuum. Units cm/sec 
        public const double LIGHTSPEED = 2.9979e10;
        public const string ID = "HUMAN";
        public const double MAX_DISTANCE = 20000;

        private double _angle;
        private double _speed;
        private double _targetDistance;

        public double Angle
        {
            get => _angle;
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("Angle cannot be less than 1 degree.");
                if (value > 89) throw new ArgumentOutOfRangeException("Angle cannot be 90 degrees or larger.");
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

        public Cannon()
        {
            TargetDistance = new Random().NextDouble() * MAX_DISTANCE;
        }

    }
}
