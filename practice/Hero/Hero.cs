using System;

namespace Transformers
{
    internal partial class Program
    {
        public class Hero
        {
            public Transformer ChooseHero()
            {
                Console.WriteLine("Please choose transformer: Optimus Prime (1), Jazz (2), Bumblebee (3).");
                var useruserInput = Console.ReadLine();
                Transformer transformer;

                switch (useruserInput)
                {
                    case "1": transformer = new OptimusPrime(ChooseWeapon(), ChooseScanner()); break;
                    case "2": transformer = new Jazz(ChooseWeapon(), ChooseScanner()); break;
                    case "3": transformer = new Bumblebee(ChooseWeapon(), ChooseScanner()); break;
                    default: throw new ArgumentException();
                }

                if (transformer.CheckIfAlive())
                {
                    return transformer;
                }
                else
                {
                    throw new ArgumentException("This transformer cannot fight, he's already dead!");
                }
            }

            public Weapon ChooseWeapon()
            {
                Console.WriteLine("Please choose weapon: Laser (1), Missile (2), Machine (3).");
                var useruserInput = Console.ReadLine();
                Weapon weapon;

                switch (useruserInput)
                {
                    case "1": weapon = new LaserWeapon(); break;
                    case "2": weapon = new MissileWeapon(); break;
                    case "3": weapon = new MachineWeapon(); break;
                    default: throw new ArgumentException();
                }

                return weapon;
            }

            public Scanner ChooseScanner()
            {
                Console.WriteLine("Please choose scanner: Sonar (1), Optical (2), Ally or Enemy (3).");
                var useruserInput = Console.ReadLine();
                Scanner scanner;

                switch (useruserInput)
                {
                    case "1": scanner = new SonarScanner(); break;
                    case "2": scanner = new OpticalScanner(); break;
                    case "3": scanner = new AllyOrEnemyScanner(); break;
                    default: throw new ArgumentException();
                }

                return scanner;
            }
        }
    }
}