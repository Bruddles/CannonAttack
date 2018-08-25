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

        private double _angle;
        private double _speed;

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
                if (value <= 0) throw new ArgumentOutOfRangeException("Speed cannot be less than or equal to 0m/s.");
                if (value > LIGHTSPEED) throw new ArgumentOutOfRangeException("Speed cannot be greater than the speed of light.");
                _speed = value;
            }
        }

        public Cannon() { }

    }
}
