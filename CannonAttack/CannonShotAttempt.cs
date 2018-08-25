using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack
{
    public class CannonShotAttempt
    {
        // Speed of Light in a Vacuum. Units m/sec 
        public const double LIGHTSPEED = 2.9979e8;
        public const double MIN_ANGLE = 1;
        public const double MAX_ANGLE = 89;

        private double _angle;
        private double _speed;

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

        public CannonShotAttempt(double angle, double speed)
        {
            Angle = angle;
            Speed = speed;
        }

    }
}
