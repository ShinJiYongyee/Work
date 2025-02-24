using System.Formats.Asn1;

namespace L20250224
{
    class BitArray32
    {
        public uint Data;   //0000 0000 0000 0000

        public void On(int position)
        {
            Data = Data | (uint)(1 << (position - 1));
        }

        public void Off(int position)
        {
            Data = Data & ~(uint)(1 << (position - 1));
        }

        public bool Check(uint other)
        {
            return (int)(Data & other) > 0 ? true : false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BitArray32 bitArray1 = new BitArray32();   //0000
            BitArray32 bitArray2 = new BitArray32();

            bitArray1.On(3);   //0100
            bitArray1.On(1);   //0101

            Console.WriteLine(Convert.ToString(bitArray1.Data, 2));

            bitArray1.Off(1);  //0100
            Console.WriteLine(Convert.ToString(bitArray1.Data, 2));

            Console.WriteLine(bitArray1.Check(bitArray2.Data));
            

        }

    }

}
