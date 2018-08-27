using System;

namespace CannonAttack
{
    class CannonAttack
    {
        public static Cannon CannonInstance;

        static void Main(string[] args)
        {
            CannonInstance = Cannon.GetInstance();

            Play();
        }

        private static void Play()
        {
            Console.WriteLine("Welcome to Cannon Attack");
            Console.WriteLine($"Target Distance: {CannonInstance.TargetDistance}m");

            GetInputsAndShoot();

            Console.ReadKey();
        }

        private static void GetInputsAndShoot()
        {
            var angle = GetAngle();
            var speed = GetSpeed();

            var attempt = new CannonShotAttempt(angle, speed);
            var result = CannonInstance.Shoot(attempt);

            if (result.Hit)
            {
                Console.Write($"Hit - {CannonInstance.PreviousShotResults.Count} shot(s)");
                Console.Write("Would you like to play again? (Y/N)");
                var answerKey = Console.ReadKey();
                var answer = answerKey.Key == ConsoleKey.Y;
                if (answer)
                {
                    CannonInstance.Reset();
                    Play();
                }
            }
            else
            {
                Console.WriteLine($"Missed shot landed at {result.ShotDistance}m");
                GetInputsAndShoot();
            }
        }

        private static double GetAngle() {
            Console.WriteLine($"Enter Angle:");
            if (!double.TryParse(Console.ReadLine(), out double angle))
            {
                return GetAngle();
            }
            return angle;
        }

        private static double GetSpeed()
        {
            Console.WriteLine($"Enter Speed:");
            if (!double.TryParse(Console.ReadLine(), out double speed))
            {
                return GetSpeed();
            }
            return speed;
        }
    }
}
