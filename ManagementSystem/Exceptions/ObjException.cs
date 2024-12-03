using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Exceptions
{
    // Exception class for handling object related errors
    internal class ObjException : ApplicationException
    {
        public ObjException()
        {
        }
        public ObjException(string message) : base(message)
        {
        }
    }

    // Exception for handling objects without a ToString method
    internal class NoToStringException : ObjException
    {
        public NoToStringException()
        {
        }
        public NoToStringException(string message) : base(message)
        {
        }
    }
}
