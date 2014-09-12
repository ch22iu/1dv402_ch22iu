using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace writeWithAst_v38
{
    class Program
    {
        private const byte max = 79;
        static void Main(string[] args)
        {
            byte columns = 0;

            do
            {
                columns = ReadOddByte(Strings.Start_Message + max + ": ", max);
                RenderAwesomeDaimond(columns);
            } while(IsContinuing());

        }
        private static byte ReadOddByte(string prompt = null, byte maxValue = max)
        {
            byte columns = 0;
            bool ifSuccess = false;
            while (!ifSuccess)
            {
                
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    columns = byte.Parse(input);
                    if (columns % 2 != 1 && columns <= maxValue)
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
                    Console.WriteLine(Strings.Error_Message, maxValue);
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
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        aCount = aCount + 2;
                        sCount = sCount - 1;
                        if (aCount == (maxCount +2))
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
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(" ");
            }
            for (int x = 0; x < aCount; x++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("*");
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
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
