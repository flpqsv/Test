namespace Transformers
{
    internal partial class Program
    {
        public abstract class Transformer
        {
            protected readonly Weapon Weapon;
            protected readonly Scanner Scanner;
            protected bool IsTransformed = true;
            protected bool IsAlive = true;
            protected int HP = 100;

            protected Transformer(Weapon weapon, Scanner scanner)
            {
                Weapon = weapon;
                Scanner = scanner;
            }

            public abstract int Fire();
            public abstract void Run();
            public abstract void FindEnemy();
            public abstract void Transform();
            public abstract void GetShot(int Damage);
            public abstract bool CheckIfAlive();
            public abstract string BecomeWinner();
            public abstract string TellName();
        }
    }
}