using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{

    public class Engine
    {
        World world;
        GameObject[] gameObject = new GameObject[3];

        ConsoleKeyInfo key;
        public void Load()
        {
            world = new World();
            gameObject[0] = new Player();
            gameObject[1] = new Monster();
            gameObject[2] = new Goal();
        }
        public void Render()
        {
            for (int y = 0; y < world.map.GetLength(0); y++)
            {
                for (int x = 0; x < world.map.GetLength(1); x++)
                {

                    if (y == gameObject[1].Y && x == gameObject[1].X)
                    {
                        Console.Write(gameObject[1].shape);
                        continue;
                    }
                    else if (y == gameObject[0].Y && x == gameObject[0].X)
                    {
                        Console.Write(gameObject[0].shape);
                        continue;
                    }
                    else if (y == gameObject[2].Y && x == gameObject[2].X)
                    {
                        Console.Write(gameObject[2].shape);
                        continue;
                    }
                    else
                    {
                        Console.Write(world.map[y, x]);

                    }
                }
                Console.WriteLine();
            }
        }
        public bool IsPressed(ConsoleKeyInfo PressedKey)
        {
            return PressedKey==Console.ReadKey();
        }
        public void Update()
        {
            key=Console.ReadKey();
            Console.Clear();
            foreach(GameObject ob in gameObject)
            {
                ob.RefreshPosition(key.Key);
            }
            Render();

        }
        public void Run()
        {
            while (true)
            {
                Update();
                if (IsGameOver())
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                if (IsWin())
                {
                    Console.WriteLine("You Win");
                    if (IsPressed(Console.ReadKey()))
                    {
                        Console.Clear();
                        Load();
                        Render();
                    }

                }
            }
        }
        public bool IsGameOver()
        {
            if (gameObject[0].Y==gameObject[1].Y && gameObject[0].X == gameObject[1].X)
            {
                return true;
            }
            return false;
        }
        public bool IsWin()
        {
            if (gameObject[0].Y == gameObject[2].Y && gameObject[0].X == gameObject[2].X)
            {
                return true;
            }
            return false;
        }
    }
}
