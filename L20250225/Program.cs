using System.Linq.Expressions;

namespace L20250225
{
    class DynamicArray2<T>
    {
        protected T[] data;
        protected int count;

        public DynamicArray2()             //초기화하는 시점 명시
        {
            data = new T[10];
            count = 0;
        }

        public void Add(T newData)
        {
            if (count >= data.Length)
            {
                T[] newArray = new T[data.Length * 2];
                Array.Copy(data, newArray, data.Length);
                data = newArray;
            }
            data[count] = newData;
            count++;

        }

        public void RemoveAt(int index)
        {
            for (int i = index + 1; i < data.Length; i++)
            {
                data[i - 1] = data[i];
            }
            count--;
        }

        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicArray2<int> dynamicArray = new DynamicArray2<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);

            dynamicArray.RemoveAt(0);

            for (int i = 0; i < dynamicArray.Count; i++)
            {
                Console.WriteLine(dynamicArray[i]);
            }
        }
    }
}
