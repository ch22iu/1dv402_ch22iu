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
                    if (numberOfSalaries < 2)
                    {
                        ViewMessage("Need to input atleast 2 salaries for begin a calculation.", backgroundColor: ConsoleColor.Red);
                    }
                    else
                    {
                        break;
                    }
                }
                while (true);

                salaries = ReadSalaries(numberOfSalaries);
                ViewResult(salaries);
            } while (isContinuing());
            }
        
        private static bool isContinuing()
        {
            {
                ViewMessage("Press anykey for continue. ESC - Quit!", backgroundColor: ConsoleColor.Blue);
               // return Console.ReadKey(true).Key != ConsoleKey.Escape
                if(Console.ReadKey(true).Key == ConsoleKey.Escape)
                    return false;
                else
                {
                    Console.Clear();
                    return true;
                }
            }
        }

        private static int[] ReadSalaries(int count)
        {
            List<int> salaries = new List<int>();

            for (int i = 1; i <= count; i++)
            {
                salaries.Add(ReadInt(String.Format("Add {0} salarie: ", i)));
            }
                return salaries.ToArray();
        }
        private static int ReadInt(string prompt)
        {

            string row;
            int number;

            do
            {
                Console.Write(prompt);
                row = Console.ReadLine();
                try
                {
                    number = Int32.Parse(row);
                    break;
                }

                catch (FormatException)
                {
                    ViewMessage(String.Format("ERROR! ERROR! '{0}' cannot convert string to int.", row), backgroundColor: ConsoleColor.Red);
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    ViewMessage(String.Format("ERROR! ERROR! ERROR! '{0}' Input something", row), backgroundColor: ConsoleColor.DarkRed);
                //}
                catch (OverflowException)
                {
                    ViewMessage(String.Format("ERROR! ERROR! ERROR! '{0}' to high value.", row), backgroundColor: ConsoleColor.DarkRed);
                }

            } while (true);
            
            return number;
        }

        private static void ViewMessage(string message, 
            ConsoleColor backgroundColor = ConsoleColor.Red, 
            ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.WriteLine();
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }
        private static void ViewResult(int[] salaries)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Median:                  {0:c0}", salaries.Median());
            Console.WriteLine("Median Average:          {0:c0}", salaries.Average());
            Console.WriteLine("Median Dispertion:       {0:c0}", salaries.Dispertion());
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < salaries.Length; i += 3)
            {
                for (int j = 0; i + j < salaries.Length && j < 3; j++)
                {
                    
                    Console.WriteLine(strings.mySalaries, salaries[i + j]);
                }
              
            }
        }

    }
}
