using System;
using System.Collections.Generic;

namespace Second
{
    partial class VirtualWallet
    {
        public class Authorization
        {
            public void ChooseAction()
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*****\nWelcome to ✿ VIRTUAL WALLETS ✿! What would you like to do?:\n(1) Registration, (2) Login.\n*****");
                    Console.ResetColor();

                    var userOperation = Console.ReadLine();

                    switch (userOperation?.ToLower())
                    {
                        case "1": Registration.Registrate(); break;
                        case "2": Login.LogIn(); break;
                        default: throw new ArgumentException($"Invalid operation {userOperation}.");
                    }
                }
                
            }

            public static void Logout()
            {
                if (IsLogin)
                {
                    Console.WriteLine("You are successfully logout from the system.");
                    IsLogin = false;
                }
                else
                    Console.WriteLine("You are not logged in the system.");
            }
        }
    }
}
