namespace L20250211
{
    public class Program
    {

        static void Main(string[] args)
        {
            Monster[] monsters = new Monster[2];

            monsters[0] = new Goblin();
            monsters[1] = new Slime();

            monsters[0].Move();
            monsters[1].Move();
        }
    }
}
