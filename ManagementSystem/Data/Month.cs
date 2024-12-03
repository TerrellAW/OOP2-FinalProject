using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    internal class Month : EventDate
    {
        private int _monthNumber;
        private string _monthName;
        private int _daysInMonth;

        public int MonthNumber
        {
            get { return _monthNumber; }
            set { _monthNumber = value; }
        }
        public string MonthName
        {
            get { return _monthName; }
            set { _monthName = value; }
        }
        public int DaysInMonth
        {
            get { return _daysInMonth; }
            set { _daysInMonth = value; }
        }

        public Month()
        {
        }

        internal int GetMonthNumber(SLL dateList, int index)
        {
            EventDate selectedDate = (EventDate)dateList.GetFromIndex(index);

            int monthNum = selectedDate.Month;

            return monthNum;
        }

        internal string GetMonthName(int monthNum)
        {
            switch (monthNum)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: throw new ArgumentOutOfRangeException("monthNum", "Month number must be from 1 to 12.");
            }
        }

        internal void SetDaysInMonth(int monthNum, int currYear)
        {
            if (monthNum == 2)
            {                
                //Check if year is a leap year
                if (currYear % 400 == 0 && currYear % 100 == 0 || currYear % 4 == 0)
                {
                    _daysInMonth = 29;
                }
                else
                {
                    _daysInMonth = 28;
                }
            }
            else if (monthNum == 4 || monthNum == 6 || monthNum == 9 || monthNum == 11)
            {
                _daysInMonth = 30;
            }
            else
            {
                _daysInMonth = 31;
            }
        }
    }
}
