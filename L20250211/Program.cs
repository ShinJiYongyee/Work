namespace L20250211
{
    public class Program
    {

        static void Main(string[] args)
        {
            Player player = new Player();
            Random rand = new Random();



            while (true)
            {
                int goblinCount = rand.Next(0, 3);
                Goblin[] goblins=new Goblin[goblinCount];
                if (goblinCount > 0) 
                { 
                    for (int i = 0; i < goblins.Length; i++) 
                    {
                        goblins[i] = new Goblin();
                    }
                }

                int slimeCount = rand.Next(1, 5);
                Slime[] slimes = new Slime[slimeCount];
                for (int i = 0; i < slimes.Length; i++)
                {
                    slimes[i] = new Slime();
                }

                int hogCount = rand.Next(1, 3);
                Hog[] hogs = new Hog[hogCount];
                for (int i = 0; i < hogs.Length; i++)
                {
                    hogs[i] = new Hog();
                }
                //Input();
                Console.ReadKey();
                Console.Clear();

                //Update();
                player.Move();
                for (int i = 0; i < goblins.Length; i++) 
                {
                    goblins [i].Move();
                }
                for(int i=0; i< slimes.Length; i++)
                {
                    slimes [i].Move();
                }
                for (int i = 0; i < hogs.Length; i++)
                {
                    hogs [i].Move();
                }

                //Render();

            }
        }
    }
}
