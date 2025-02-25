namespace L20250225
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicArray dynamicArray = new DynamicArray();
            dynamicArray.Add(0);
            Console.WriteLine($"dynamicArray[{0}] = " + dynamicArray[0]);

            dynamicArray.Add(1);
            Console.WriteLine($"dynamicArray[{1}] = " + dynamicArray[1]);

            dynamicArray.Add(2);
            Console.WriteLine($"dynamicArray[{2}] = " + dynamicArray[2]);

            dynamicArray.Add(3);
            Console.WriteLine($"dynamicArray[{3}] = " + dynamicArray[3]);

            dynamicArray.RemoveAt(2);

            for (int i = 0; i < dynamicArray.Count(); i++)
            {
                Console.WriteLine($"dynamicArray[{i}] = " + dynamicArray[i]);
            }
            int a = dynamicArray[1];
            Console.WriteLine(a);
        }
    }
}
