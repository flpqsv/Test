namespace Transformers
{
    internal partial class Program
    {
        public abstract class Weapon
        {
            protected int Ammo = 100;
            protected int Damage;
            protected int Critical;
            protected int Counter = 0;

            public abstract void Reload(ref string Name);
            public abstract int Fire(ref string Name);
            public abstract int DefineDamage();
            public abstract int DefineCritical();
        }
    }
}