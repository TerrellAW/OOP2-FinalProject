using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    internal class Event
    {
        // Fields
        private int _id;
        private string _name;
        private string _date;
        private string _location;
        private string _description;
        public static SLL eventList = new SLL();

        // Properties
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }

        // Constructor
        public Event(string name, string date, string location, string description)
        {
            _name = name;
            _date = date;
        }
        public Event()
        {
        }

    }
}