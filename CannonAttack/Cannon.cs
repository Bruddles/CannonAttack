using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack
{
    public class Cannon
    {
        public const string DEFAULT_ID = "HUMAN";
        public const double MAX_DISTANCE = 20000;
        
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

        public List<CannonShotResult> PreviousShotResults;

        private Cannon()
        {
            Id = DEFAULT_ID;
            TargetDistance = CalculateTargetDistance();
            PreviousShotResults = new List<CannonShotResult>();
        }

        public static Cannon GetInstance()
        {
            if (_instance == null)
                _instance = new Cannon();

            return _instance;
        }

        public CannonShotResult Shoot(CannonShotAttempt attempt)
        {
            var result = new CannonShotResult(attempt, TargetDistance);

            PreviousShotResults.Add(result);

            return result;
        }

        public void Reset() {
            TargetDistance = CalculateTargetDistance();
            PreviousShotResults = new List<CannonShotResult>();
        }

        private double CalculateTargetDistance() {
            return new Random().NextDouble() * MAX_DISTANCE;
        }
    }
}
