using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Exceptions
{
    internal class SLLException : ApplicationException
    {
        public SLLException()
        {
        }
        public SLLException(string message) : base(message)
        {
        }
    }

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
