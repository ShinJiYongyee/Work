namespace empty
{

    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int index = 0;

            for (int i = 2; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    list.Add(i*j);
                }
            }

            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine($"{i}x{j}=" + list[index]);
                    index++;
                }
            }
        }
    }
}
