using System;

namespace Transformers
{
    internal partial class Program
    {
        public class OptimusPrime : DriverTransformer
        {
            public OptimusPrime(Weapon weapon, Scanner scanner) : base(weapon, scanner) { }
            public string Name = "Optimus Prime";

            public override int Fire()
            {
                int damage = Weapon.Fire(ref Name);
                Weapon.Reload(ref Name);

                return damage;
            }

            public override void Run()
            {
                Console.WriteLine($"{Name} is running.");
            }

            public override void FindEnemy()
            {
                Scanner.Scan(ref Name);
            }

            public override void Transform()
            {
                if (IsTransformed)
                {
                    Console.WriteLine($"{Name} is transforming.");
                    IsTransformed = false;
                }
            }

            public override void Drive()
            {
                if (IsTransformed)
                {
                    Console.WriteLine($"{Name} is driving.");
                }
                else
                {
                    Console.WriteLine($"{Name} cannot drive until transforms.");
                }
            }

            public override void GetShot(int damage)
            {
                HP -= damage;

                Console.WriteLine($"{Name} got shot! HP: {HP}.");

                if (HP <= 0)
                {
                    Console.WriteLine($"{Name} died!");
                    IsAlive = false;
                }
            }

            public override bool CheckIfAlive()
            {
                if (!IsAlive)
                    return false;

                return true;
            }

            public override string BecomeWinner()
            {
                return $"╰(▔∀▔)╯ {Name} won! ╰(▔∀▔)╯";
            }

            public override string TellName()
            {
                return Name;
            }
        }
    }
}