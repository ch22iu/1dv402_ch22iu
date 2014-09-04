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
        private static uint ReadUint(string prompt, uint minValue)
        {
            return (50);
        }
    }
}
