using System.Formats.Asn1;
using System.Xml;

namespace L20250224
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //1. nxn 정사각형 크기 공백과 벽 -> n^2 정수 배열, 0과 1
            //2. 둘중 하나가 벽이면 벽, 둘 다 공백이면 공백 -> or
            //3. 정수 배열 암호

            int n = 5;
            int[] arr1 = { 9, 20, 28, 18, 11 };
            int[] arr2 = { 30, 1, 21, 17, 28 };
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = arr1[i] | arr2[i];
            }

            int bitMask = 0b00000001;

            for (int i = 0; i < n; ++i)
            {
                bitMask = 1 << (n - 1);
                //Convert.ToString(result[i], 2)
                for (int j = 0; j < 8; j++)
                {
                    Console.Write((bitMask & result[i]) > 0 ? "#" : " ");
                    bitMask = bitMask >> 1;
                }
                Console.WriteLine();
            }

        }

    }

}
