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

                    }
                }
                catch
                {

                }
            }
            return columns;
        }
        private static void RenderAwesomeDaimond(byte maxCount)
        {

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
