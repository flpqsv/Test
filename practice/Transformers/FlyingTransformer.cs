namespace Transformers
{
    internal partial class Program
    {
        public abstract class FlyingTransformer : Transformer
        {
            protected FlyingTransformer(Weapon weapon, Scanner scanner) : base(weapon, scanner) { }

            public abstract void Fly();
        }
    }
}