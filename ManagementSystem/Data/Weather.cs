using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ManagementSystem.Data
{
    /// <summary>
    /// Weather class is responsible for storing weather data fetched from the VisualCrossing API.
    /// The class is a template that specifies what data is needed from the API response.
    /// The ToString method is overridden to provide a string representation of the object for use in the application.
    /// </summary>
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
