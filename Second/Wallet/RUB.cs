using System;

namespace Second
{
    partial class VirtualWallet
    {
        public class RUB : Wallet
        {
            public override string Name()
            {
                return "RUB";
            }

            public override void AddMoney()
            {
                Console.WriteLine("Please enter the sum: ");
                var userInput = Console.ReadLine();

                if (!double.TryParse(userInput, out double result))
                    Console.WriteLine("You can enter only numbers.");
                else
                    Sum += result;

                Console.WriteLine($"Balance: {Sum}{Name()}");
            }

            public override void WithdrawMoney()
            {
                Console.WriteLine("Please enter the sum: ");
                var userInput = Console.ReadLine();

                if (!double.TryParse(userInput, out double result))
                    Console.WriteLine("You can enter only numbers.");
                else if (result > Sum)
                    Console.WriteLine("You do not have enough funds.");
                else
                    Sum -= result;

                Console.WriteLine($"Balance: {Sum}{Name()}");
            }

            public override void ConvertFrom(ref double result)
            {
                if (result > Sum)
                    Console.WriteLine("You do not have enough funds.");
                else
                    Sum -= result;

                Console.WriteLine($"Balance: {Sum}{Name()}");
            }

            public override void ConvertTo(ref double convertedSum)
            {
                Sum += convertedSum;

                Console.WriteLine($"Balance: {Sum}{Name()}");
            }

            public override void WithdrawAll()
            {
                if (Sum > 0)
                {
                    Console.WriteLine($"Current balance: {Sum}{Name()}");

                    Sum -= Sum;

                    Console.WriteLine($"All funds have been withdrawn to your card. Balance: {Sum}{Name()}\n*****");
                }
                else
                {
                    Console.WriteLine($"Wallet {Name()} is empty or hasn't been enabled yet.");
                }
            }
        }
    }
}
