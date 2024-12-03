using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    // TODO:
    // 1. Compare date string to weather date string to get weather for the day
    // 2. Compare date string to event date string to get events for the day
    // 3. Delete this class and merge functionality with EventDate
    internal class Day : EventDate
    {
        // Fields
        private int _id;
        private string _date;
        private SLL _events;
        private Weather _weather;

        // Properties
        
    }
}
