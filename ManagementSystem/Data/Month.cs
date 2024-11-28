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

    internal class Month
    {
        private int _monthNumber;
        private int _yearNumber;
        private int _daysInMonth;

        public int MonthNumber
        {
            get { return _monthNumber; }
        }

        internal int GetMonthNumber(string date)
        {
            string[] dateData = date.Split('-');

            int monthNum = int.Parse(dateData[0]);
            string monthStr = dateData[1];

            switch (monthStr)
            {
                case "January": return 1;
                case "February": return 2;
                case "March": return 3;
                case "April": return 4;
                case "May": return 5;
                case "June": return 6;
                case "July": return 7;
                case "August": return 8;
                case "September": return 9;
                case "October": return 10;
                case "November": return 11;
                case "December": return 12;
                default: throw new ArgumentOutOfRangeException("date", "Invalid date format.");
            }
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
