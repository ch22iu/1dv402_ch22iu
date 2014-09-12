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
                columns = ReadOddByte(Strings.Start_Message + max + ": ", max)
                RenderAwesomeDaimond(columns);
            } while(IsContinuing());

        }
        private static byte ReadOddByte(string prompt = null, byte maxValue = max)
        {
            return;
        }
        private static void RenderAwesomeDaimond(byte maxCount)
        {

        }
        static void rows(int maxCount, int aCount)
        {

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
