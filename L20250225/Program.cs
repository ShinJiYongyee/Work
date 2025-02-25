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
            
            Console.WriteLine("\n8번째 인덱스 지움(범위 벗어남)");
            dynamicArray.RemoveAt(8);
            for (int i = 0; i < dynamicArray.Count(); i++)
            {
                Console.WriteLine($"dynamicArray[{i}] = " + dynamicArray[i]);
            }

            Console.WriteLine("\n2번째 인덱스 지움");
            dynamicArray.RemoveAt(2);
            for (int i = 0; i < dynamicArray.Count(); i++)
            {
                Console.WriteLine($"dynamicArray[{i}] = " + dynamicArray[i]);
            }

            Console.WriteLine();
            int a = dynamicArray[1];
            Console.WriteLine("dynamicArray[1] = "+a);
        }
    }
}
