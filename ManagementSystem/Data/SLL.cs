using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Exceptions;

namespace ManagementSystem
{
    internal abstract class SLL : ILinkedListADT
    {
        private Node? _head;
        private int _size;

        public SLL()
        {
            _head = null;
            _size = 0;
        }

        public bool IsEmpty()
        {
            Node? currNode = _head;
            if (currNode == null)
            {
                return true;
            }
            return false;
        }

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
            while(currNode.Next != null)
            {
                currNode = currNode.Next;
            }

            currNode.Next = newNode;
            _size++;
        }

        public int GetSize()
        {
            return _size;
        }

        public void GetData(int size)
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
    }
}
