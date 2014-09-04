using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace moneyexchange_v37
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadPositiveDouble("Value: "));
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
