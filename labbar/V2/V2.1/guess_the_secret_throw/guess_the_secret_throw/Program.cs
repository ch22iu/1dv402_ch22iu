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
            Test.Run();

            bool continue = false;
            int number = 0;
            string message = null;
            SecretNumber secretNumber = new SecretNumber();

            do
            {
                secretNumber.Initialize();

                while (secretNumber.CanMakeGuess)
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("| Guess the secret word between 1 - 100 |");
                    Console.WriteLine("========================================");

                    if (secretNumber.Count > 0)
                    {
                        GuessedNumber[] results = secretNumber.GuessedNumbers;
                        for (int i = 0;i < secretNumber.Count; i++)
                        {
                            Console.Write(" {0} ", results[i].Number);
                        }

                    }
                    if (!String.IsNullOrWhiteSpace(message))
                    {
                        Console.WriteLine(message);
                        Console.WriteLine();
                    }


                }
            }
        }
    }
}
