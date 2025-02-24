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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BitArray32 bitArray32 = new BitArray32();   //0000

            bitArray32.On(3);   //0100
            bitArray32.On(1);   //0101

            Console.WriteLine(Convert.ToString(bitArray32.Data, 2));

            bitArray32.Off(1);  //0100
            Console.WriteLine(Convert.ToString(bitArray32.Data, 2));

        }

    }

}
