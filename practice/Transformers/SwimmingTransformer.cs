namespace Transformers
{
    internal partial class Program
    {
        public abstract class SwimmingTransformer : Transformer
        {
            protected SwimmingTransformer(Weapon weapon, Scanner scanner) : base(weapon, scanner) { }

            public abstract void Swim();
        }
    }
}