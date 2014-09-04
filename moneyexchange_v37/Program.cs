using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace moneyexchange_v37
{
    public class Program
    {
        static void Main(string[] args)
        {
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

                


                
                subtotal = ReadPositiveDouble("Total sum:");
                total = Convert.ToUInt32(Math.Round(subtotal, 2
     ));
                cash = ReadUint("My money:", total);
                charge = cash - total;
                receiptsRoundOff = Math.Round(total - subtotal
    , 2);
                addings = SplitIntoDenom(charge, denom);
                
                ViewReciept(subtotal, receiptsRoundOff, total, cash, charge, addings, denom);
                ViewMessage("Continue or press ESC for exit.");
                anyKey = Console.ReadKey();
        
            }
            while (anyKey.Key != ConsoleKey.Escape);
        }
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
                    }
                }
                catch (FormatException)
                {
                    ViewMessage("Error, No valid number", true);
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
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
            }
            Console.ResetColor();
            return;
        }
        static private void ViewReciept(double subtotal, double Amount, uint total, uint cash, uint charge, uint[] notes, uint[] denom)
        {
            Console.WriteLine("\n");
            Console.WriteLine("My Receipts");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("{0,-15} : {1,10:c2}","Sub Total: ", subtotal);
            Console.WriteLine("{0,-15} : {1,10:c2}","Amount:", Amount);
            Console.WriteLine("{0,-15} : {1,10:c2}", "Total:", total);
            Console.WriteLine("{0,-15} : {1,10:c2}", "Cash:", cash);
            Console.WriteLine("{0,-15} : {1,10:c2}", "Of:", charge);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\n");

            for (int i = 0; i < denom.Length; i++)
            {
                if (notes[i] > 0)
                {
                    Console.WriteLine("{0,-5} : {1,4}", denom[i], notes[i]);
                }

            }
            Console.WriteLine("Cant save your recept atm.");
        }
        private static uint ReadUint(string prompt, uint minValue)
        {
            uint input = 0;

            while (input < minValue)
            {
                try
                {
                    Console.Write(prompt);
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
