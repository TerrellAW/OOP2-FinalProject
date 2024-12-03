using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    // Unecessary class
    internal class DateList : SLL
    {
        public DateList()
        {
        }

        // Worst function ever
        //internal static DateList ExtractDates(WeatherList weatherList)
        //{
        //    int i = 0;
        //    DateList dateList = new DateList();
        //    Weather current = (Weather)weatherList.GetFromIndex(i);
        //    EventDateTime dateTime = new EventDateTime();
        //    while (current != null)
        //    {
        //        string[] dateData = current.Date.Split('-');

        //        dateTime.Year = int.Parse(dateData[0]);
        //        dateTime.Month = int.Parse(dateData[1]);
        //        dateTime.Day = int.Parse(dateData[2]);

        //        dateList.Add(dateTime);

        //        i++;
        //        current = (Weather)weatherList.GetFromIndex(i);
        //    }
        //    return dateList;
        //}

        // Unecessary function
        //internal DateTime GetCurrentDate()
        //{
        //    DateTime currentDate = DateTime.Now;

        //    return currentDate;
        //}
    }
}
