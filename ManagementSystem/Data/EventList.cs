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
    /// Extends the SLL class and adds additional methods for managing events.
    /// 
    /// Methods:
    /// 1. GetEventByDate(string date) - Returns an event object from the list if it has the same date as the one passed in.
    /// 2. ListEvents() - Return a list of events that can be used in a foreach loop.
    /// </summary>
    public class EventList : SLL
    {
        // Returns event data from the list if it matches the data passed in.
        public Event? GetEventByDate(string date)
        {
            Node? currNode = Head;
            Debug.WriteLine($"Searching for date: {date}");
            Debug.WriteLine($"Current list size: {Size}");

            while (currNode != null)
            {
                Debug.WriteLine($"Current node data type: {currNode.Data?.GetType()}");
                Debug.WriteLine($"Current node data: {currNode.Data}");
                if (currNode.Data is Event varEvent && !string.IsNullOrEmpty(varEvent.EventDate))
                {
                    Debug.WriteLine($"Checking event: {varEvent.EventName} with date: {varEvent.EventDate}");

                    string eventDateOnly = varEvent.EventDate.Split(' ')[0];
                    
                    if (eventDateOnly == date)
                    {
                        Debug.WriteLine("Event found: " + varEvent.EventName);
                        return varEvent;
                    }
                    
                }
                currNode = currNode.Next;
            }
            Debug.WriteLine("No matching event found.");
            return null;
        }

        // Return a list of events
        public List<Event> ListEvents()
        {
            List<Event> events = new List<Event>();
            Node? currNode = Head;

            while (currNode != null)
            {
                if (currNode.Data is Event varEvent)
                {
                    events.Add(varEvent);
                }
                currNode = currNode.Next;
            }
            return events;
        }
    }
}
