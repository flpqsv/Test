using System;

namespace Transformers
{
    internal partial class Program
    {
        public class OpticalScanner : Scanner
        {
            public override void Scan(ref string Name)
            {
                Console.WriteLine($"{Name} is using optical scanner to detect enemies.");
            }
        }
    }
}