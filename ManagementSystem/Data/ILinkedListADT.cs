using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManagementSystem
{
    public interface ILinkedListADT
    {
        public bool IsEmpty();
        public void Add(object data);
        public int GetSize();
        public void PrintData(int size);
    }
}
