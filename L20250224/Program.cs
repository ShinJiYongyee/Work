using System.Formats.Asn1;
using System.Xml;

namespace L20250224
{

    internal class Program
    {
        static void Main(string[] args)
        {
            uint N = 3;
            ulong[] X = new ulong[N];

            X[0] = 3;
            X[1] = 5;
            X[2] = 7;

            ulong result = 0;
            for (int i = 0; i < N; i++)
            {
                ulong value = 1;
                for(int n = 1; n < 64; n++)
                {
                    value = value << 1;
                    if(X[i] < value)
                    {
                        result = result ^ value;
                        break;
                    }
                }
            }

            Console.WriteLine(result);

        }

    }

}
