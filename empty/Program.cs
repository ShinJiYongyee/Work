namespace empty
{

    public class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader input = new(new
            BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter output = new(new
            BufferedStream(Console.OpenStandardOutput(), bufferSize));

        static int N;
        static int K = 0;
        static string[] s = new string[21];

        static string Hanoi(int N, int from, int to, int by)
        {

            if (s[N] != null)
            {
                return s[N];
            }
            if (N == 1)
            {
                K++;
                return s[N] = $"{from} {to}\n";
            }
            else
            {

                string left = Hanoi(N - 1, from, by, to);
                K++;
                string mid = $"{from} {to}\n";
                string right = Hanoi(N - 1, by, to, from);

                return s[N] = left+mid+right;
            }

        }

        static void Main(string[] args)
        {
            N = int.Parse(input.ReadLine());
            Hanoi(N, 1, 3, 2); //(N from to by)
            output.WriteLine(K);
            foreach (string s in s)
            {
                output.WriteLine(s);
            }
            output.Flush();
        }
    }


}
