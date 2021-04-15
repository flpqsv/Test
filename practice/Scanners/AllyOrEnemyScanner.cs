using System;

namespace Transformers
{
    internal partial class Program
    {
        public class AllyOrEnemyScanner : Scanner
        {
            public override void Scan(ref string Name)
            {
                Console.WriteLine($"{Name} is using ally-or-enemy scanner to detect enemies.");
            }
        }
    }
}