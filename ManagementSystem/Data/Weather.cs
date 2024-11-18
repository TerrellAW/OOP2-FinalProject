using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ManagementSystem.Data
{
    // TODO: Summary comment with class description
    internal class Weather
    {
        // Fields
        private string _datetime = "";
        private string _temp = "";
        private string _description = "";

        // Properties TODO: Add error handling
        internal string Datetime
        {
            get
            {
                return _datetime;
            }
            set
            {
                _datetime = value;
            }
        }
        internal string Temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value;
            }
        }
        internal string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        // Constructors
        internal Weather()
        {
        }
        internal Weather(string Datetime, string Temp, string Description)
        {
            this.Datetime = Datetime;
            this.Temp = Temp;
            this.Description = Description;
        }

        // Methods
        public override string ToString()
        {
            return $"Datetime: {Datetime}\n Temp: {Temp}\n Description: {Description}";
        }
    }
}
