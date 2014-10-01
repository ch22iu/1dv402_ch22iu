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
            loadingContent();


            byte columns = 0;

            do
            {
                columns = ReadOddByte(Strings.Start_Message + max + Strings.Colon, max);
                RenderAwesomeDaimond(columns);
            } while(IsContinuing());

        }
        private static void loadingContent()
        {
            Console.WriteLine(Strings.Application_load);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine(Strings.Application_reload);
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);

            Console.Clear();
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
                    if (columns % 2 != 0 && columns <= maxValue)
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
            for (byte i = 1; i <= maxCount; i += 2)
            {
                rows(maxCount, i);
            }

            for (int i = maxCount - 2; i >= 1; i -= 2)
            {
                rows(maxCount, i);
            }
        }


        // This method is rending rows of the daimond and adding spaces and the "*"
        static void rows(int maxCount, int aCount)
        {
            int space = (maxCount - aCount) / 2;

            for (int i = 0; i < space; i++)
            {
                Console.Write(Strings.Empty);
            }
            for (int j = 0; j < aCount; j++)
            {
                Console.Write(Strings.Dot);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }

        // Bool is continuing. Running program until its stops or if anykey is press down.
        static bool IsContinuing()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Strings.Correct_Message);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(Strings.Continue_Prompt);
            
            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
