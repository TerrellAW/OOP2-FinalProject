using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Exceptions
{
    // Exception class for handling API related errors
    internal class APIException : HttpRequestException
    {
        public APIException()
        {
        }
        public APIException(string message) : base(message)
        {
        }
    }
    // Exception for handling API connection errors
    internal class APIConnectionException : APIException
    {
        public APIConnectionException()
        {
        }
        public APIConnectionException(string message) : base(message)
        {
        }
    }

    // Exception for handling API data errors
    internal class APIDataException : APIException
    {
        public APIDataException()
        {
        }
        public APIDataException(string message) : base(message)
        {
        }
    }
}