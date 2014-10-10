using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02B
{
    class NumberDisplay
    {
        private int _number;
        private int _maxnumber;


        public NumberDisplay(int maxNumber)
            : this(maxNumber, 0)
        {
        }

        public NumberDisplay(int maxNumber, int number)
        {
            MaxNumber = maxNumber;
            Number = number;
        }

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value >= 0 && value <= MaxNumber)
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("Värdet måste vara större än noll och mindre än " + MaxNumber);
                }
            }
        }

        public int MaxNumber
        {
            get
            {
                return _maxnumber;
            }
            set
            {
                if (value > 0)
                {
                    _maxnumber = value;
                }
                else
                {
                    throw new ArgumentException("Värdet måste vara större än 0");
                }
            }
        }
        //Ökar Number med 1. Om Number är lika med MaxNumber ställs Number till 0.
        public void Increment()
        {
            if (Number == MaxNumber)
            {
                Number = 0;
            }
            else
            {
                Number++;
            }
        }
        //Överlagring av ToString som returnerar Number i strängform.
        public string ToString()
        {
            return Number.ToString();
        }
        //Överlagring av ToString med en formatsträng som parameter. Om formatsträngen är "G" eller "0" och om numret är 10 eller över inleds inte numret med nolla. Om formatsträngen är "00" och talet är under 10 inleds numret med en nolla.
        public string ToString(string format)
        {
            if (format == "G" || format == "0")
            {
                return Number.ToString();
            }
            else if (format == "00" && Number < 10)
            {
                return "0" + Number.ToString();
            }
            else if (format == "00" && Number >= 10)
            {
                return Number.ToString();
            }
            else
            {
                throw new FormatException("Felaktigt format");
            }
        }
    }
}
