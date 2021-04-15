using System;
using System.Linq;
using System.Threading;

namespace Second
{
    partial class VirtualWallet
    {
        public class User
        {
            bool USD;
            bool EUR;
            bool UAH;
            bool RUB;
            bool CNY;

            Wallet walletUSD = new USD();
            Wallet walletEUR = new EUR();
            Wallet walletUAH = new UAH();
            Wallet walletRUB = new RUB();
            Wallet walletCNY = new CNY();

            public void ChooseAction()
            {
                var continueWorking = true;

                while (continueWorking)
                {
                    while (continueWorking)
                    {
                        Console.WriteLine("Options:\n(1) Add new wallet\n(2) Add money to the existing wallet\n(3) Withdraw money\n(4) Convert your funds\n(5) Check the currency rate");
                        var userOperation = Console.ReadLine();

                        switch (userOperation?.ToLower())
                        {
                            case "1": AddWallet(); break;
                            case "2": AddMoney(); break;
                            case "3": WithdrawMoney(); break;
                            case "4": ConvertMoney(); break;
                            case "5": CheckRate(); break;
                            default: throw new ArgumentException($"Invalid operation {userOperation}.");
                        }

                        Console.WriteLine("Would you like to continue? Y/N");
                        var userReply = Console.ReadLine();

                        if (userReply.ToUpper() != "Y")
                            continueWorking = false;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please note that all the funds will be withdrawn once you log out. Are you sure that you'd like to log out? Y/N");
                    Console.ResetColor();

                    var userReply2 = Console.ReadLine();

                    if (userReply2.ToUpper() == "N")
                        continueWorking = true;
                }

                Wait();
                walletUSD.WithdrawAll();
                Wait();
                walletEUR.WithdrawAll();
                Wait();
                walletUAH.WithdrawAll();
                Wait();
                walletRUB.WithdrawAll();
                Wait();
                walletCNY.WithdrawAll();
                Wait();

                Authorization.Logout();
            }

            private static void Wait()
            {
                Random time = new Random();
                int seconds = time.Next(1000, 1001);
                Thread.Sleep(seconds);
            }

            private void AddWallet()
            {
                Console.WriteLine("Add new wallet. Options:\n(1) USD Wallet\n(2) EUR Wallet\n(3) UAH Wallet\n(4) RUB Wallet\n(5) CNY Wallet");
                var userOperation = Console.ReadLine();

                switch (userOperation?.ToLower())
                {
                    case "1": USD = true; break;
                    case "2": EUR = true; break;
                    case "3": UAH = true; break;
                    case "4": RUB = true; break;
                    case "5": CNY = true; break;
                    default: throw new ArgumentException($"Invalid operation {userOperation}.");
                }
            }

            private void AddMoney()
            {
                Console.WriteLine("Choose the wallet:\n(1) USD Wallet\n(2) EUR Wallet\n(3) UAH Wallet\n(4) RUB Wallet\n(5) CNY Wallet");
                var userOperation = Console.ReadLine();

                if (userOperation == "1" & USD == true)
                    walletUSD.AddMoney();
                else if (userOperation == "2" & EUR == true)
                    walletEUR.AddMoney();
                else if (userOperation == "3" & UAH == true)
                    walletUAH.AddMoney();
                else if (userOperation == "4" & RUB == true)
                    walletRUB.AddMoney();
                else if (userOperation == "5" & CNY == true)
                    walletCNY.AddMoney();
                else
                    Console.WriteLine("There is no such wallet or you haven't enabled it yet.");
            }

            private void WithdrawMoney()
            {
                Console.WriteLine("Choose the wallet:\n(1) USD Wallet\n(2) EUR Wallet\n(3) UAH Wallet\n(4) RUB Wallet\n(5) CNY Wallet");
                var userOperation = Console.ReadLine();

                if (userOperation == "1" & USD == true)
                    walletUSD.WithdrawMoney();
                else if (userOperation == "2" & EUR == true)
                    walletEUR.WithdrawMoney();
                else if (userOperation == "3" & UAH == true)
                    walletUAH.WithdrawMoney();
                else if (userOperation == "4" & RUB == true)
                    walletRUB.WithdrawMoney();
                else if (userOperation == "5" & CNY == true)
                    walletCNY.WithdrawMoney();
                else
                    Console.WriteLine("There is no such wallet or you haven't enabled it yet.");
            }

            private void ConvertMoney()
            {
                var firstWallet = ChooseFirstWallet();
                var secondWallet = ChooseSecondWallet();
                double currency1 = 0;
                double currency2 = 0;
                double convertedSum;


                if (firstWallet == secondWallet)
                    throw new ArgumentException("You cannot convert the same currency.");

                Console.WriteLine("Enter the sum: ");
                var userSum = Console.ReadLine();

                if (!double.TryParse(userSum, out double result))
                    Console.WriteLine("You can enter only numbers.");
                else if (result <= 0)
                    Console.WriteLine("The sum cannot be under 0.");
                else
                    firstWallet.ConvertFrom(ref result);

                foreach (var x in CurrencyRate)
                    if (x.Key.Contains(firstWallet.Name()))
                        currency1 = x.Value;

                foreach (var x in CurrencyRate)
                    if (x.Key.Contains(secondWallet.Name()))
                        currency2 = x.Value;

                convertedSum = CurrencyRate.ElementAt(0).Value / currency1 * result * currency2;

                secondWallet.ConvertTo(ref convertedSum);
            }

            private Wallet ChooseSecondWallet()
            {
                Console.WriteLine("Choose the second wallet:\n(1) USD Wallet\n(2) EUR Wallet\n(3) UAH Wallet\n(4) RUB Wallet\n(5) CNY Wallet");
                var secondWallet = Console.ReadLine();

                if (secondWallet == "1" & USD == true)
                    return walletUSD;
                else if (secondWallet == "2" & EUR == true)
                    return walletEUR;
                else if (secondWallet == "3" & UAH == true)
                    return walletUAH;
                else if (secondWallet == "4" & RUB == true)
                    return walletRUB;
                else if (secondWallet == "5" & CNY == true)
                    return walletCNY;
                else
                    throw new ArgumentException("There is no such wallet or you haven't enabled it yet.");
            }

            private Wallet ChooseFirstWallet()
            {
                Console.WriteLine("Choose the wallet:\n(1) USD Wallet\n(2) EUR Wallet\n(3) UAH Wallet\n(4) RUB Wallet\n(5) CNY Wallet");
                var firstWallet = Console.ReadLine();

                if (firstWallet == "1" & USD == true)
                    return walletUSD;
                else if (firstWallet == "2" & EUR == true)
                    return walletEUR;
                else if (firstWallet == "3" & UAH == true)
                    return walletUAH;
                else if (firstWallet == "4" & RUB == true)
                    return walletRUB;
                else if (firstWallet == "5" & CNY == true)
                    return walletCNY;
                else
                    throw new ArgumentException("There is no such wallet or you haven't enabled it yet.");
            }

            private void CheckRate()
            {
                foreach (var x in CurrencyRate)
                    Console.WriteLine("{0} - {1}", x.Key, x.Value);
            }
        }
    }
}
