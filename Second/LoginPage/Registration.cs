using System;
using System.Linq;

namespace Second
{
    partial class VirtualWallet
    {
        public class Registration : Authorization
        {
            public static void Registrate()
            {
                if (!IsLogin)
                {
                    Console.WriteLine("Please, enter your login:");
                    var login = Console.ReadLine();

                    if (!ConfirmLogin(ref login))
                        return;

                    Console.WriteLine("Please, enter the password:");
                    var password = Console.ReadLine();

                    if (!Users.TryAdd(login, password))
                        Console.WriteLine($"User with login {login} already exists.");
                    else
                    {
                        Console.WriteLine($"You have been successfully registered in the system as user with login {login}.");
                        Login.LogIn();
                    }
                }
                else
                    Console.WriteLine("You are already logged in the system.");
            }

            private static bool ConfirmLogin(ref string login)
            {
                while (IsLoginExist(login))
                {
                    Console.WriteLine("Do you want try again? Y/N");

                    if (Console.ReadLine().ToLower() == "y")
                    {
                        Console.WriteLine("Please, enter login again:");
                        login = Console.ReadLine();
                    }
                    else
                        return false;
                }

                return true;
            }

            private static bool IsLoginExist(string login)
            {
                if (!ConfirmValidForm(ref login))
                    return true;

                var result = Users.Keys.Any(key => key.Equals(login));

                if (result)
                    Console.WriteLine($"User with login {login} already exists in the system.");

                return result;
            }

            private static bool ConfirmValidForm(ref string login)
            {
                bool validation = true;

                if (login.Length < 3 || login.Length > 10)
                {
                    Console.WriteLine("Wrong login length: it must include 3-10 characters. Try again.");
                    validation = false;
                }
                for (int i = 0; i < login.Length; i++)
                {
                    if (!(Char.IsDigit(login[i]) || login[i] >= 'a' && login[i] <= 'z' || login[i] >= 'A' && login[i] <= 'Z'))
                    {
                        Console.WriteLine("Wrong login format: non-latin characters. Try again.");
                        validation = false;
                        break;
                    }
                }

                return validation;
            }
        }
    }
}
