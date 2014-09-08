using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Threading;

namespace moneyexchange_v37
{
    public class Program
    {
        public static void Main(string[] args)
        {
            loadingContent();

            ConsoleKeyInfo anyKey;
            uint[] denom = new uint[] { 500, 100, 50, 20, 10, 5, 1 };
            uint[] addings = new uint[denom.Length];

            do
            {
                double receiptsRoundOff = 0;
                double subtotal = 0;
                uint cash = 0;
                uint total = 0;
                uint charge = 0;

                subtotal = (double)ReadPositiveDouble("Enter your total amount of money with decimal(s):");
                
                total = Convert.ToUInt32(Math.Round(subtotal, 2
     ));

                cash = ReadUint("Total amount that you pay with:", total);

                charge = cash - total;

                receiptsRoundOff = Math.Round(total - subtotal
    , 2);
                addings = SplitIntoDenom(
                    charge, 
                    denom);
                
                ViewReciept(
                    subtotal, 
                    receiptsRoundOff, 
                    total, 
                    cash, 
                    charge, 
                    addings, 
                    denom);

                ViewMessage("Type y for create new (recipe), or press ESC for exit.");

                Console.WriteLine("\n");
                anyKey = Console.ReadKey();
                Console.Clear();

                if ((anyKey.KeyChar == 'Y') || (anyKey.KeyChar == 'y'))
                {
                    // Timer t = new Timer(Timer, null, 0, 2000);

                    savingData();
                }
                else
                {
                    Environment.Exit(0);
                }
                
            }
            while (true);
        }
        private static void savingData()
        {
            Console.WriteLine("Starting new recept for you.");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Saving to database.");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Clearing data for you.");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
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
       // private static void Timer(Object o)
      //  {

            
      //      GC.Collect();
            
     //   }
        static private double ReadPositiveDouble(string prompt)
        {
            double input = 0;
            double values = 0;

            while (values < 1)
            {
                try
                {
                    ViewMessage(prompt);
                    input = double.Parse(Console.ReadLine());
                    values = Math.Round(input);

                    if (values < 1)
                    {
                        ViewMessage("Error amount to small!", true);
                        Console.WriteLine("\n");
                    }
                }
                catch (FormatException)
                {
                    ViewMessage("Error, No valid number.", true);
                    Console.WriteLine("\n");
                }
            }
            return input;
        }
        // Själva den total summan som ska betalas.
        // Räknar ut varje "denom" som betalaren ska få tillbaka.
        static private uint[] SplitIntoDenom(uint changeValue, uint[] denom)
        {
            uint myReceipts = 0;
            uint[] myDenom = new uint[denom.Length];
            for (int i = 0; i < denom.Length; i++)
            {
                myReceipts = changeValue / denom[i];
                myDenom[i] = myReceipts;
                changeValue = changeValue % denom[i];
            }
            return (myDenom);
        }
        // Skriver ut ett meddelande ifall om något är fel.
        // Om ett meddelande har något fel så skriver den ut annars inte.
        static private void ViewMessage(string message, bool isError = false)
        {
            if(isError)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(message);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(message);
            }
            Console.ResetColor();
            return;
        }
        static private void ViewReciept(double subtotal, double Amount, uint total, uint cash, uint charge, uint[] notes, uint[] denom)
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("My Receipts");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("{0,-15} : {1,10:C}","Total", subtotal);
            Console.WriteLine("{0,-15} : {1,10:C}", "Money paid in", cash);
            Console.WriteLine("{0,-15} : {1,10:C}","Amount Rounding", Amount);
            Console.WriteLine("{0,-15} : {1,10:C}", "New amount", total);

            Console.WriteLine("{0,-15} : {1,10:C}", "Money back", charge);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\n");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Calculating dollar(s)");
            Console.WriteLine("--------------------------------------------");
            for (int i = 0; i < denom.Length; i++)
            {
                if (notes[i] > 0)
                {
                    Console.WriteLine("{0,-5:C} : {1,3}", denom[i], notes[i]);
                }

            }
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("Information about your payment");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-15:C} : {1,10:C}", "Total cost", subtotal);
            Console.WriteLine("{0,-15:C} : {1,10:C}", "Total paid in", cash);
            Console.WriteLine("{0,-15:C} : {1,10:C}", "You got back", charge);
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine("\n");
            Console.WriteLine("Reciept will be downloaded in a few days.");
            Console.WriteLine("\n");
        }
        private static uint ReadUint(string prompt, uint minValue)
        {
            uint input = 0;
            while (input < minValue)
            {

                try
                {

                    Console.Write(prompt);
                    Console.WriteLine();
                    input = uint.Parse(Console.ReadLine());
                    
                    if (input < minValue)
                        {
                            ViewMessage("Error, Number not in range!", true);
                        }
                }
                catch (FormatException)
                {
                    ViewMessage("Error, This is not a valid number!", true);
                }
            }
            return (input);
        }
    }
}
