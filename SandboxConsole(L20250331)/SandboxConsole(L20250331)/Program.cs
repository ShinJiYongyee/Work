namespace SandboxConsole_L20250331_
{
    internal class Program
    {
        static void foo(int repeatCount, int maxNum)
        {
            if (repeatCount > maxNum)
            {
                return;
            }
            foo(repeatCount + 1, maxNum);
            bar(repeatCount, maxNum);
            Console.WriteLine();
        }
        static void bar(int repeatCount, int maxNum)
        {
            if (repeatCount > maxNum)
            {
                return;
            }
            bar(repeatCount + 1, maxNum);
            Console.Write('*');
        }

        static void Main(string[] args)
        {
            //for (int i = 1; i <= 5; i++)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        Console.Write('*');
            //    }
            //    Console.WriteLine();
            //}

            //삼각형 그리기를 수행하는 두 개의 재귀함수
            foo(1, 5);

        }
    }
}
