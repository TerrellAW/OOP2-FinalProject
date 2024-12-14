using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class Node
    {
        private object _data;
        private Node? _next;

        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Node? Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public Node(object data)
        {
            Data = data;
            Next = null;
        }
    }
}
