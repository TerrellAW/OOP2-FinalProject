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
    /// 
    /// Methods:
    /// 1. IsEmpty() - Checks if the list is empty.
    /// 2. Add() - Adds a new node to the end of the list.
    /// 3. PrintData() - Prints the data in the list.
    /// 4. GetFromIndex() - Returns an object stored at a specific index.
    /// </summary>
    public class SLL : ILinkedListADT
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
    }
}
