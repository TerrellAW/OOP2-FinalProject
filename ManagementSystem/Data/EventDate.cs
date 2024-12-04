using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManagementSystem
{
    internal class EventDate
    {
        // TODO:
        // 1. Separate dates from weatherList
        // 2. Put dates in dateList
        // 3. Get current date
        // 4. Merge day, month, year into this class

        private int _year;
        private int _month;
        private int _day;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }
        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }

        internal EventDate()
        {
        }

        internal EventDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
    }
}
