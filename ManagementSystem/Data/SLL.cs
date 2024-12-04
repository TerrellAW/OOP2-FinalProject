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
    /// Implementation of the ILinkedListADT interface.
    /// </summary>
    internal class SLL : ILinkedListADT
    {
        private Node? _head;
        private int _size;

        public Node? Head
        {
            get { return _head; }
        }
        public int Size
        {
            get { return _size; }
        }

        public SLL()
        {
            _head = null;
            _size = 0;
        }

        // Checks if the list is empty by checking if the head is null.
        public bool IsEmpty()
        {
            Node? currNode = _head;
            if (currNode == null)
            {
                return true;
            }
            return false;
        }

        // Adds a new node to the end of the list.
        public void Add(object data)
        {
            Node newNode = new Node(data);
            Node? currNode = _head;

            if (currNode == null)
            {
                _head = newNode;
                _size++;
                return;
            }
            while (currNode.Next != null)
            {
                currNode = currNode.Next;
            }

            currNode.Next = newNode;
            _size++;
        }

        // Prints the data in the list. Good for debugging.
        public void PrintData(int size)
        {
            object currObj;
            Node? currNode = _head;

            for (int i = 0; i < size; i++)
            {
                if (currNode == null)
                {
                    throw new ListNullException("Error: List contains no data");
                }
                try
                {
                    currObj = currNode.Data;
                    Debug.WriteLine(currObj.ToString());
                    currNode = currNode.Next;
                }
                catch (NoToStringException)
                {
                    throw new NoToStringException("Error: Object does not have a ToString() method");
                }
            }
        }

        // Returns an object stored at a specific index.
        public object GetFromIndex(int index)
        {
            Node? currNode = _head;

            for (int i = 0; i < index; i++)
            {
                if (currNode == null)
                {
                    throw new ListNullException("Error: List contains no data");
                }
                currNode = currNode.Next;
            }
            return currNode.Data;
        }
        // Returns a field from an object stored in the list if it matches the data passed in.
        public Weather? GetWeatherDataByDate(string date)
        {
            Node? currNode = _head;

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
