using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace writeWithAst_v38
{
    class Program
    {
        // Fixes
        private const byte max = 0;
        // Fixes
        static void Main(string[] args)
        {
            loadingContent();


            byte columns = 0;

            do
            {
                columns = ReadOddByte(Strings.Start_Message + max + ": ", max);
                RenderAwesomeDaimond(columns);
            } while(IsContinuing());

        }
        private static void loadingContent()
        {
            Console.WriteLine("Loading application...");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 5% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 10% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 15% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 20% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 25% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 30% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 35% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 40% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 45% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 50% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 55% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 60% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 65% finish.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Application 75% finish.");
            System.Threading.Thread.Sleep(600);
            Console.WriteLine("Application 80% finish.");
            System.Threading.Thread.Sleep(600);
            Console.WriteLine("Application 85% finish.");
            System.Threading.Thread.Sleep(600);
            Console.WriteLine("Application 90% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 91% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 92% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 93% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 94% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 95% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 96% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 97% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 98% finish.");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("Application 99% finish.");
            System.Threading.Thread.Sleep(600);
            Console.WriteLine("Application 100% finish.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\n");
            Console.WriteLine("Reloading Interface...");
            Console.WriteLine("\n");
            System.Threading.Thread.Sleep(2000);

            Console.Clear();
        }
        private static byte ReadOddByte(string prompt = null, byte maxValue = max)
        {
            byte columns = 0;
            // Fixes
            bool ifSuccess = true;
            // Fixes
            while (!ifSuccess)
            {
                
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    columns = byte.Parse(input);
                    // Fixes
                    if (columns % 2 != 1 && columns <= maxValue)
                    // Fixes
                    {
                        ifSuccess = true;
                        break;
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Strings.Error_Message, maxValue);
                        Console.ResetColor();
                    }

                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Strings.Error_Message_Text, maxValue);
                    Console.ResetColor();
                }
            }
            return columns;
        }
        private static void RenderAwesomeDaimond(byte maxCount)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            int aCount = 1;
            int sCount = maxCount / 2;
            bool testing = false;
            while (aCount != 0)
            {
                for (int i = 0; i < maxCount; i++)
                {
                    rows(sCount, aCount);
                    if (testing == false)
                    {
                        
                        aCount = aCount + 2;
                        sCount = sCount - 1;
                        if (aCount == (maxCount + 2))
                        {
                            testing = true;
                            aCount = aCount - 2;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            sCount = sCount + 1;
                        }
                    }
                    if (testing == true)
                    {
                        if (aCount != 1)
                        {
                            aCount = aCount - 2;
                        }
                        else
                        {
                            aCount = aCount - 1;
                            break;
                        }
                        sCount = sCount + 1;
                    }

                }
            }

        }
        static void rows(int maxCount, int aCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(" ");
            }
            for (int x = 0; x < aCount; x++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static bool IsContinuing()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Strings.Correct_Message);
            Console.ResetColor();
            Console.WriteLine();
            if(Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
