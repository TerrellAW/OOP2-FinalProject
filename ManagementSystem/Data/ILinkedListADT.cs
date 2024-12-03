using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManagementSystem
{
    /// <summary>
    /// ADT interface for linked list.
    /// Includes necessary methods for linked list.
    /// </summary>
    public interface ILinkedListADT
    {
        public bool IsEmpty();
        public void Add(object data);
        public void PrintData(int size);
        public object GetFromIndex(int index);
    }
}
