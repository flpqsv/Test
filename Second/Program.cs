using System;
using System.Collections.Generic;
using System.Linq;

namespace Second
{
    partial class VirtualWallet
    {
        private static readonly Dictionary<string, double> CurrencyRate = new Dictionary<string, double> {{"USD", 1}, {"EUR", 0.84}, {"UAH", 27.85}, {"RUB", 76.34}, {"CNY", 6.54}};
        private static readonly Dictionary<string, string> Users = new Dictionary<string, string>();
        private static bool IsLogin;

        static void Main(string[] args)
        {
            var loginPage = new Authorization();
            loginPage.ChooseAction();
        }
    }
}
