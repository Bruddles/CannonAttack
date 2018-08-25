using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack
{
    public class Cannon
    {
        public const string ID = "HUMAN";

        private double _angle;

        public double Angle {
            get { return _angle; }
            set {
                if (value < 1) throw new ArgumentOutOfRangeException("Angle cannot be less than 1 degree.");
                if (value > 89) throw new ArgumentOutOfRangeException("Angle cannot be 90 degrees or larger.");
                _angle = value;
            }
        }

        public double Speed;

        public Cannon() { }
        
    }
}
