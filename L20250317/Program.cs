using Newtonsoft.Json.Linq;

namespace L20250317
{
    class HelloWorld
    {
        public int Gold;
        public int MP;
        public int HP;

        public HelloWorld(int inGold = 100, int inHP = 100, int inMP = 100)
        {
            this.Gold = inGold;
            this.HP = inHP;
            this.MP = inMP;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string Data = "{\r\n\tGold : 10,\r\n\tHP : 20,\r\n\tMP : 30\r\n}";

            JObject Json = JObject.Parse(Data);
            Console.WriteLine(Json.Value<int>("Gold"));
            Console.WriteLine(Json.Value<int>("HP"));
            Console.WriteLine(Json.Value<int>("MP"));

        }
    }
}
