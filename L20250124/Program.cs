namespace L20250124
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum=0;

            for(int i = 0; i < 0; i %= 2) 
            {
                sum=sum+i;
            }
            Console.WriteLine($"합:{sum}");

        }
    }
}
