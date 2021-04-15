using System;

namespace Transformers
{
    internal partial class Program
    {
        public class Jazz : FlyingTransformer
        {
            public Jazz(Weapon weapon, Scanner scanner) : base(weapon, scanner) { }
            public string Name = "Jazz";

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

            public override void Fly()
            {
                if (IsTransformed)
                    Console.WriteLine($"{Name} is flying.");
                else
                    Console.WriteLine($"{Name} cannot fly until transforms.");
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