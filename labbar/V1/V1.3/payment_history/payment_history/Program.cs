using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payment_history
{
    class Program
    {
        public static void Main(string[] args)
        {
            int numberOfSalaries;
            int[] salaries;

            do
            {
                do
                {
                    numberOfSalaries = ReadInt("How many salaries: ");
                    if(numberOfSalaries < 2)
                    {
                        ViewMessage(strings.isError, ConsoleColor.Green, ConsoleColor.White);
                    }
                    else
                    {
                        break;
                    }
                    while (true);

                    salaries = ReadSalaries(numberOfSalaries);
                    ViewResult();
                } while (isContinuing());
           
        
        private static bool isContinuing()
        {
            {
                ViewMessage(Console.Write(strings.isError), ConsoleColor.Red, ConsoleColor.Blue)
            }
         return true;
        }
        private static bool isContinuing()
        {
            ViewMessage(strings.valueError, ConsoleColor.Red,ConsoleColor.Blue);

            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        private static int[] ReadSalaries(int count)
        {
            List<int> salaries = new List<int>();

            for (int i = 0; i < count; i++)
            {
                salaries.Add(ReadInt(String.Format("Pay {0}: ", i)));
            }
                return salaries.ToArray();
        }
        private static int ReadInt(string prompt)
        {
            int number = 0;
            string input;
            bool success = false;

            while (!success)
            {
                try
                {

                }
                catch
                {
                    ViewMessage(strings.valueError, ConsoleColor.Red, ConsoleColor.White);
                }
            }
            return number;
        }
        private static void ViewMessage(string message, ConsoleColor backgroundColor, ConsoleColor textColor)
        {
            Console.WriteLine();
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine();
            Console.ResetColor();
        }
        private void ViewResult(int[] salaries)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            for (int i = 0; i + j < salaries.Length && j < 3; j++)
            {
                Console.Write("{0,7}, salaries[i + j])"
            }
        }

    }
}
