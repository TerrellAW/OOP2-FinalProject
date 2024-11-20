using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Exceptions
{
    internal class APIException : HttpRequestException
    {
        // Constructors
        public APIException() : base()
        {
        }
        // Custom exception
        internal APIException(string message) : base(message)
        {
        }
    }
}
