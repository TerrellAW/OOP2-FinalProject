using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Exceptions;

namespace ManagementSystem
{
    /// <summary>
    /// Extends the SLL class and adds additional methods for managing weather data.
    /// 
    /// Methods:
    /// 1. GetWeatherDataByDate(string date) - Returns a weather object from the list if it is for the date passed in.
    /// </summary>
    public class WeatherList : SLL
    {
        // Returns a field from an object stored in the list if it matches the data passed in.
        public Weather? GetWeatherDataByDate(string date)
        {
            Node? currNode = Head;

            while (currNode != null)
            {
                if (currNode.Data is Weather weather && weather.Date == date)
                {
                    return weather;
                }
                currNode = currNode.Next;
            }
            return null;
        }
    }
}
