using System;
using System.Collections.Generic;

namespace Transformers
{
    internal partial class Program
    {
        public class Fight
        {
            private static readonly List<string> Winners = new List<string>();
            private static bool IsFighting = true;

            public void StartFighting()
            {
                int game = 1;

                while (IsFighting)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    var hero = new Hero();
                    var firstFighter = hero.ChooseHero();
                    var secondFighter = hero.ChooseHero();
                    var random = new Random();

                    Console.WriteLine("Let's start the fight! (⌐■_■)\n______________________________________________");

                    firstFighter.FindEnemy();
                    secondFighter.FindEnemy();
                    firstFighter.Transform();
                    secondFighter.Transform();
                    firstFighter.Run();
                    secondFighter.Run();

                    Console.WriteLine("______________________________________________");

                    while (firstFighter.CheckIfAlive() & secondFighter.CheckIfAlive())
                    {
                        int fighter = random.Next(1, 3);
                        if (fighter == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            secondFighter.GetShot(firstFighter.Fire());

                            Console.WriteLine("****************");
                        }
                        else if (fighter == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            firstFighter.GetShot(secondFighter.Fire());

                            Console.WriteLine("****************");
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;

                    if (firstFighter.CheckIfAlive())
                    {
                        Console.WriteLine(firstFighter.BecomeWinner());
                        Winners.Add($"Game #{game}. Winner: {firstFighter.TellName()}");
                    }
                    else if (secondFighter.CheckIfAlive())
                    {
                        Console.WriteLine(secondFighter.BecomeWinner());
                        Winners.Add($"Game #{game}. Winner: {secondFighter.TellName()}");
                    }

                    ++game;

                    ContinueOrStop();
                }

                ShowResults();
            }

            private static void ShowResults()
            {
                foreach (var x in Winners)
                    Console.WriteLine(x);
            }

            private void ContinueOrStop()
            {
                Console.WriteLine("(⌐■_■) Do you want to fight again? Yes (1), No (2)");
                var userReply = Console.ReadLine();

                if (userReply != "1")
                    IsFighting = false;
            }
        }
    }
}