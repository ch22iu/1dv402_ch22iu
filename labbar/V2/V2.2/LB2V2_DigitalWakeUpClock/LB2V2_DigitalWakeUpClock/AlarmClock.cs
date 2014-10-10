using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02B
{
    class AlarmClock
    {
        private ClockDisplay _alarmTime = new ClockDisplay();
        private ClockDisplay _time = new ClockDisplay();


        public AlarmClock()
            : this(0, 0)
        {
        }

        public AlarmClock(int hour, int minute)
            : this(hour, minute, 0, 0)
        {
        }

        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }

        public int AlarmHour
        {
            get
            {
                return _alarmTime.Hour;
            }
            set
            {
                _alarmTime.Hour = value;
            }
        }

        public int AlarmMinute
        {
            get
            {
                return _alarmTime.Minute;
            }
            set
            {
                _alarmTime.Minute = value;
            }
        }

        public int Hour
        {
            get
            {
                return _time.Hour;
            }
            set
            {
                _time.Hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return _time.Minute;
            }
            set
            {
                _time.Minute = value;
            }
        }
        //Anropar Clockdisplayobjektets "Increment"-metod. Om tiden är samma som alarmtiden returneras true, annars false.
        public bool TickTock()
        {
            _time.Increment();
            if (Hour == AlarmHour && Minute == AlarmMinute)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Överlagring av ToString som returnerar tiden och alarmtiden inom parentes.
        public string ToString()
        {
            return _time.ToString() + " (" + _alarmTime.ToString() + ")";
        }
    }
}
