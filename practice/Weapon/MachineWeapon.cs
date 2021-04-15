using System;

namespace Transformers
{
    internal partial class Program
    {
        public class MachineWeapon : Weapon
        {

            public override void Reload(ref string Name)
            {
                if (Ammo > 0)
                {
                    Console.WriteLine($"{Name} is reloading the machine gun.");
                    Ammo--;
                    Console.WriteLine($"Ammo left: {Ammo}");
                }
                else
                {
                    Console.WriteLine("No ammo left!");
                }
            }

            public override int Fire(ref string Name)
            {
                if (Ammo > 0)
                {
                    Console.WriteLine($"{Name} is using the machine gun.");

                    if (Counter < 2)
                    {
                        DefineDamage();
                        Console.WriteLine($"Damage: {Damage}");
                        Counter += 1;
                        return Damage;
                    }
                    else
                    {
                        DefineCritical();
                        Console.WriteLine($"Critical: {Critical}");
                        Counter = 0;
                        return Critical;
                    }
                }
                else
                {
                    Console.WriteLine($"{Name} has no ammo left, he cannot shot anymore.");
                    return 0;
                }
            }

            public override int DefineDamage()
            {
                var random = new Random();
                Damage = random.Next(5, 26);

                return Damage;
            }

            public override int DefineCritical()
            {
                Critical = DefineDamage() * 4;

                return Critical;
            }
        }
    }
}