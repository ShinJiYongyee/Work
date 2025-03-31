namespace SandboxConsole_L20250331_
{
    internal class Program
    {
        static void Lee(int repeatCount) //재귀함수, num에서 시작
        {

            if (repeatCount <= 0) //기저 조건
            {
                return;
            }
            Console.Write('*');
            Lee(repeatCount - 1); //재귀 조건
        }

        static void Main(string[] args)
        {

            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.Write('*');
            //}

            Lee(5);
        }
    }
}
