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
                double subAmount = 0;
                uint myMoney = 0;
                uint total = 0;
                uint charge = 0;

                charge = myMoney - total;
                receiptsRoundOff = Math.Round(total - subAmount
                    , 2);
                total = Convert.ToUInt16(Math.Round(subAmount, 2
                    ));
                addings = SplitIntoDenom(charge, denom);
                subAmount = ReadPositiveDouble("Total:");
                myMoney = ReadUint("My money:", total);

                ViewMessage("Continue or press ESC for exit.");
                anyKey = Console.ReadKey();
        
            }
            while (anyKey.Key != ConsoleKey.Escape);
        }
        private static double ReadPositiveDouble(string prompt = null)
        {
            double startValue = 0;
            bool startReading = true;
            while (startReading)
            {

                {
                    // Skriver ut..
                    if (prompt != null)
                    {
                        Console.Write(prompt);
                    }
                    startValue = 0;
                    // Kollar upp och byter ut värde.
                    if (Double.TryParse(Console.ReadLine().Replace('.', ','), out startValue))
                    {
                        double fixValue = Math.Round(startValue, MidpointRounding.AwayFromZero);
                        if (fixValue > 0)
                        {
                            startReading = false;
                        }
                        else
                        {
                            Console.WriteLine("Error! '{0}' to small value.", startValue);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error! Error!");
                        Console.ReadLine();
                    }
                }
            }
            return startValue;
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
            Console.WriteLine("---------------");
            Console.WriteLine("{0,-10} : {2,5:c5}", subtotal);
            Console.WriteLine("{0,-10} : {2,5:c5}", subtotal);
            Console.WriteLine("{0,-10} : {2,5:c5}", subtotal);
            Console.WriteLine("{0,-10} : {2,5:c5}", subtotal);
            Console.WriteLine("{0,-10} : {2,5:c5}", subtotal);
            Console.WriteLine("\n");

            for (int i = 0; i < denom.Length; i++)
            {
                if (notes[i] > 0)
                {
                    Console.WriteLine();
                }

            }
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
