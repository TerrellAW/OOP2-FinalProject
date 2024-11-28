using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Exceptions
{
    internal class ObjException : ApplicationException
    {
        public ObjException()
        {
        }
        public ObjException(string message) : base(message)
        {
        }
    }

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
