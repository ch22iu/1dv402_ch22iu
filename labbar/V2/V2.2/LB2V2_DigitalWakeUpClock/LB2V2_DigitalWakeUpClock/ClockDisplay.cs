using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02B
{
    class ClockDisplay
    {
        public ClockDisplay()
            : this(0, 0)
        {
        }

        public ClockDisplay(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        private NumberDisplay _hourDisplay = new NumberDisplay(23);
        private NumberDisplay _minuteDisplay = new NumberDisplay(59);

        public int Hour
        {
            get
            {
                return _hourDisplay.Number;
            }
            set
            {
                _hourDisplay.Number = value;
            }
        }

        public int Minute
        {
            get
            {
                return _minuteDisplay.Number;
            }
            set
            {
                _minuteDisplay.Number = value;
            }
        }
        //Metod som ökar tiden med 1 minut om minuterna går över dess maxvärde ökar timmen med 1 också.
        public void Increment()
        {

            if (_minuteDisplay.Number == _minuteDisplay.MaxNumber)
            {
                _minuteDisplay.Increment();
                _hourDisplay.Increment();
            }
            else
            {
                _minuteDisplay.Increment();
            }
        }
        //Överlagring av metoden ToString som anropar NumberDisplayobjektets ToString-metod. Med skickas en formatsträng som anger om ett tal som är mindre än 10 ska inledas med nolla. I timmarnas fall ska det inte det. I minuternas fall ska det det.
        public string ToString()
        {
            return _hourDisplay.ToString("0") + ":" + _minuteDisplay.ToString("00");
        }

    }
}
