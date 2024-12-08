using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ManagementSystem
{
    /// <summary>
    /// Weather class is responsible for storing weather data fetched from the VisualCrossing API.
    /// The class is a template that specifies what data is needed from the API response.
    /// The ToString method is overridden to provide a string representation of the object for use in the application.
    /// </summary>
    internal class Weather : Pages
    {
        // Fields
        private string _date;
        private string _temp = "";
        private string _description = "";

        // Properties TODO: Add error handling
        internal string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
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
        internal Weather(string Date, string Temp, string Description)
        {
            this.Date = Date;
            this.Temp = Temp;
            this.Description = Description;
        }

        // Methods
        public override string ToString()
        {
            return $"Datetime: {Date}\n Temp: {Temp}\n Description: {Description}";
        }

        internal override string FormatForHTML(string input)
        {
            return input.Replace("\n", "<br />");
        }
    }
}
