using System.Collections.Generic;
using System.Linq;

namespace Second
{
    partial class VirtualWallet
    {
        public abstract class Wallet
        {
            protected double Sum = 0;

            public abstract string Name();
            public abstract void AddMoney();
            public abstract void WithdrawMoney();
            public abstract void ConvertFrom(ref double result);
            public abstract void ConvertTo(ref double convertedSum);
            public abstract void WithdrawAll();
        }
    }
}
