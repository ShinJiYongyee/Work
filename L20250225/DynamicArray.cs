using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250225
{
    public class DynamicArray
    {
        int count = 0;
        int[] ints;
        public DynamicArray()
        {
            ints = new int[0];
        }
        public DynamicArray(int count)
        {
            ints = new int[count];
        }
        public int this[int i]
        {
            get { return ints[i]; }
            set { ints[i] = value; }
        }
        public void Add(int data)
        {
            count++;
            int[] newInts = new int[count];
            for (int i = 0; i < count-1; i++)
            {
                newInts[i] = ints[i];
            }
            newInts[count-1] = data;
            ints = newInts;
        }
        public void RemoveAt(int index)
        {
            int[] newInts = new int[count - 1];
            for(int i=0; i<index; i++)
            {
                newInts[i] = ints[i];
            }
            for (int i = index; i < count-1; i++)
            {
                newInts[i] = ints[i+1];   
            }
            this.ints = newInts;
            count--;
        }
        public int Count()
        {
            return count;

        }
    }
}
