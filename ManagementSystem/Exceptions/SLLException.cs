using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Exceptions
{
    // Exception class for handling Singly Linked List related errors
    internal class SLLException : ApplicationException
    {
        public SLLException()
        {
        }
        public SLLException(string message) : base(message)
        {
        }
    }

    // Exception for handling null list errors
    internal class ListNullException : SLLException
    {
        public ListNullException()
        {
        }
        public ListNullException(string message) : base(message)
        {
        }
    }
}
