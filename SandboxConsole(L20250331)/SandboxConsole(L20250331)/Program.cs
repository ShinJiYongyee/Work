using System.Net.Http.Headers;

namespace SandboxConsole_L20250331_
{
    internal class Program
    {
        static void Lee(int repeatCount, int maxCount) //재귀함수, num에서 시작
        {

            if(repeatCount > maxCount)
            {
                return ;
            }
            Console.WriteLine(repeatCount);
            Lee(repeatCount+1, maxCount);
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(1);
            //Console.WriteLine(2);
            //Console.WriteLine(3);
            //Console.WriteLine(4);
            //Console.WriteLine(5);
            //Console.WriteLine(6);
            //Console.WriteLine(7);
            //Console.WriteLine(8);
            //Console.WriteLine(9);
            //Console.WriteLine(10);

            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            Lee(1, 10);
        }
    }
}
