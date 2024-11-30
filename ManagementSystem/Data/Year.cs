using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    internal class Year : EventDateTime
    {
        private int _year;

        public Year() 
        {
        }

        public Year(int year)
        {
            _year = year;
        }
    }
}
