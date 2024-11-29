using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    internal enum MonthEnum
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    internal class Month : EventDateTime
    {
        private int _monthNumber;
        private int _yearNumber;
        private int _daysInMonth;

        public int MonthNumber
        {
            get { return _monthNumber; }
        }

        internal int GetMonthNumber(DateList dateList, int index)
        {
            EventDateTime selectedDate = (EventDateTime)dateList.GetFromIndex(index);

            int monthNum = selectedDate.Month;

            return monthNum;
        }

        internal MonthEnum GetMonthEnum(int monthNum)
        {
            switch (monthNum)
            {
                case 1: return MonthEnum.January;
                case 2: return MonthEnum.February;
                case 3: return MonthEnum.March;
                case 4: return MonthEnum.April;
                case 5: return MonthEnum.May;
                case 6: return MonthEnum.June;
                case 7: return MonthEnum.July;
                case 8: return MonthEnum.August;
                case 9: return MonthEnum.September;
                case 10: return MonthEnum.October;
                case 11: return MonthEnum.November;
                case 12: return MonthEnum.December;
                default: throw new ArgumentOutOfRangeException("monthNum", "Month number must be from 1 to 12.");
            }
        }
    }
}
