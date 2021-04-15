using System;
using System.Linq;

namespace Second
{
    partial class VirtualWallet
    {
        public class Login : Authorization
        {
            public static void LogIn()
            {
                var user = new User();
                if (!IsLogin)
                {
                    Console.WriteLine("Please, enter your login:");
                    var login = Console.ReadLine();

                    if (!ValidateLogin(ref login))
                        return;

                    Console.WriteLine("Please, enter the password.");
                    var password = Console.ReadLine();

                    if (!ValidatePassword(login, password))
                        return;

                    Console.WriteLine($"You have been successfully logged in the system as user with login {login}.");
                    IsLogin = true;

                    user.ChooseAction();
                }
                else
                    Console.WriteLine("You are logged in the system.");
            }

            private static bool ValidateLogin(ref string login)
            {
                while (!IsLoginExist(login))
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
                var result = Users.Keys.Any(key => key.Equals(login));

                if (!result)
                    Console.WriteLine($"User with login {login} does not exist in the system.");

                return result;
            }

            private static bool ValidatePassword(string login, string password)
            {
                while (!IsPasswordCorrect(login, password))
                {
                    Console.WriteLine("Do you want try again? Y/N");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        Console.WriteLine("Please, enter your password again:");
                        password = Console.ReadLine();
                    }
                    else
                        return false;
                }

                return true;
            }

            private static bool IsPasswordCorrect(string login, string password)
            {
                var result = Users[login].Equals(password);

                if (!result)
                    Console.WriteLine("Password is incorrect.");

                return result;
            }
        }
    }
}
