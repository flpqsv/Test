using System;

namespace Transformers
{
    internal partial class Program
    {
        public class SonarScanner : Scanner
        {
            public override void Scan(ref string Name)
            {
                Console.WriteLine($"{Name} is using sonar scanner to detect enemies.");
            }
        }
    }
}