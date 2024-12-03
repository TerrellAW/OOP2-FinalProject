using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Exceptions
{
    // Exception class for handling database related errors
    internal class DBException : ApplicationException
    {
        public DBException()
        {
        }
        public DBException(string message) : base(message)
        {
        }
    }
    // Exception for handling database connection errors
    internal class DBConnectionException : DBException
    {
        public DBConnectionException()
        {
        }
        public DBConnectionException(string message) : base(message)
        {
        }
    }
}
