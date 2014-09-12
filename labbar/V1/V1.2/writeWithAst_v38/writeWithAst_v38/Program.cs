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
        private const byte max = 79;
        // Fixes
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
            System.Threading.Thread.Sleep(2000);

            Console.Clear();
        }
        private static byte ReadOddByte(string prompt = null, byte maxValue = max)
        {
            byte columns = 0;
            // Fixes
            bool ifSuccess = false;
            // Fixes
            while (!ifSuccess)
            {
                
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    columns = byte.Parse(input);
                    // Fixes
                    if (columns % 2 != 0 && columns <= maxValue)
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
                Console.Write(Strings.Empty);
            }
            for (int x = 0; x < aCount; x++)
            {
                Console.Write(Strings.Dot);
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
        }
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
            
            if(Console.ReadKey(true).Key != ConsoleKey.Escape)
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
