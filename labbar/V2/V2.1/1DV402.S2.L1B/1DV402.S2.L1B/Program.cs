using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1DV402.S2.L1B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Strings.Start_Message;

            // Testa grundläggande krav på klassen SecretNumber.
            Test.Run();

            // Deklarera och initiera lokala variabler. 
            bool continueGame = false;
            int number = 0;
            SecretNumber secretNumber = new SecretNumber();

            // Upprepa spelomgångar tills användaren avslutar genom att 
            // skriva  'nej'.
            do
            {
                // Initiera ny spelomgång.
                secretNumber.Initialize();

                // Rensa konsolfönstret och skriv ut ledtext.
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔══════════════════════════════════════╗ ");
                Console.WriteLine(" ║ Gissa det hemliga talet mellan 1-100 ║ ");
                Console.WriteLine(" ╚══════════════════════════════════════╝ ");
                Console.ResetColor();

                // Låt användaren gissa så länge det finns gissningar kvar. 
                while (secretNumber.CanMakeGuess)
                {
                    // Läs in en gissning i det slutna intervallet mellan 1 och 100.
                    Console.ForegroundColor = ConsoleColor.White;
                    do
                    {
                        Console.Write(Strings.Guess, secretNumber.Count + 1);
                    } while (!(int.TryParse(Console.ReadLine(), out number) &&
                        number >= 1 && number <= 100));
                    Console.ResetColor();
                    Console.WriteLine();

                    try
                    {
                        // Gissa och avsluta spelomgången om gissningen är rätt.
                        if (secretNumber.MakeGuess(number))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(Strings.Error);
                        Console.WriteLine(ex.Message);
                        return;
                    }

                }
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Strings.Exit);
                Console.CursorVisible = false;
                Console.CursorVisible = true;
                Console.ResetColor();
                Console.WriteLine(Strings.Empty);

                string input = Console.ReadLine();
                if (input == "ja")
                {
                    Console.Clear();
                    continueGame = true;
                }
                else if (input == "nej")
                {
                    Console.Clear();
                    continueGame = false;
                    Environment.Exit(0);
                }
                else
                {
                    continueGame = false;
                    Console.Clear();
                    Environment.Exit(0);
                }
            } while (continueGame);
        }
    }
}
