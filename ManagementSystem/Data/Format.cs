using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    /// <summary>
    /// Simple abstract class to format strings for HTML
    /// Any class that needs it can extend it and implement the FormatForHTML method
    /// </summary>
    public abstract class Format
    {
        internal abstract string FormatForHTML(string input);
    }
}
