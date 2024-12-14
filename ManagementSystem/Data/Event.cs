using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class Event
    {
        // Fields
        private int _id;
        private string _name;
        private string _date;
        private string _location;
        private string _description;
        public static SLL eventList = new SLL();

        // Properties
        public string EventName 
        { 
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string EventDate 
        { 
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        public string EventLocation 
        { 
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public string EventDescription 
        { 
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        // Constructor
        public Event(string name, string date, string location, string description)
        {
            _name = name;
            _date = date;
            _location = location;
            _description = description;
        }
        public Event()
        {
        }

        // Methods
        public override string ToString()
        {
            return $"{_name} - {_date} - {_location}\n";
        }
    }
}