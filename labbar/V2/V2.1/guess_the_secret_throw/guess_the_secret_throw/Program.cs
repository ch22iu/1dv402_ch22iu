using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace guess_the_secret_throw
{
    class Program
    {
        static void Main(string[] args)
        {

            bool repeat = false;
            int number = 0;
            string message = null;
            SecretNumber secretNumber = new SecretNumber();

            do
            {
                secretNumber.Initialize();

                while (secretNumber.CanMakeGuess)
                {
                    Console.Clear();

                    Console.WriteLine("========================================");
                    Console.WriteLine("| Guess the secret word between 1 - 100 |");
                    Console.WriteLine("========================================");

                    if (secretNumber.Count > 0)
                    {
                        GuessedNumber[] results = secretNumber.GuessedNumbers;
                        for (int i = 0; i < secretNumber.Count; i++)
                        {
                            Console.BackgroundColor = results[i].Outcome == Outcome.High ?
                                ConsoleColor.Red : ConsoleColor.Blue;
                            Console.Write(" {0} ", results[i].Number);
                        }
                        Console.ResetColor();
                        Console.WriteLine("\n");

                    }
                    if (!String.IsNullOrWhiteSpace(message))
                    {
                        Console.WriteLine(message);
                        Console.WriteLine();
                    }

                    var prompt = String.Format(Strings.Guess_Number,
                        Strings.ResourceManager.GetString(String.Format("Count_{0}", secretNumber.Count + 1)));

                    do
                    {
                        Console.Write(prompt);

                    } while (!(int.TryParse(Console.ReadLine(), out number) && number >= 1 && number <= 100));
                    Console.ResetColor();

                    try
                    {
                        if (secretNumber.MakeGuess(number) != Outcome.Right)
                        {
                            message = String.Format(Strings.ResourceManager.GetString(String.Format("Outcome_{0}",
                            secretNumber.Outcome.ToString())), secretNumber.Guess);
                        }
                        else
                        {
                            message = String.Format(Strings.Outcome_Right_Message,
                                Strings.ResourceManager.GetString(String.Format("Count_{0}", secretNumber.Count)).ToLower());
                        }
                        if (!secretNumber.CanMakeGuess && secretNumber.Outcome != Outcome.Right)
                        {
                            message += String.Format(Strings.Cannot_Guess, secretNumber.Number);
                            break;
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(Strings.Ex);
                        Console.WriteLine(exception.Message);
                        return;
                    }
                }

                Console.WriteLine();
                Console.WriteLine(message);
                Console.Write("\n  New Number? [N] Quit");
                repeat = Console.ReadKey(true).Key != ConsoleKey.N;
            } while (repeat);
        }
    }
}
