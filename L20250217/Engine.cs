using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Engine
    {

        static protected Engine instance;
        public World world;


        //유일한 엔진 인스턴스 호출 강제
        static public Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }
        protected bool IsRunning = true;
        public void Load()
        {
            //file에서 로딩
            string[] scene =
            {
                "**********",
                "*P       *",
                "*        *",
                "*        *",
                "*        *",
                "*   M    *",
                "*        *",
                "*        *",
                "*       G*",
                "**********"

            };
            world = new World();

            for(int y=0; y<scene.Length; y++)
            {
                for(int x=0; x<scene[y].Length; x++)
                {
                    if(scene[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, scene[y][x]);
                        world.Instanciate(wall);
                    }
                    else if(scene[y][x] == ' ')
                    {
                        Floor floor = new Floor(x, y, scene[y][x]);
                        world.Instanciate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        world.Instanciate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        world.Instanciate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, scene[y][x]);
                        world.Instanciate(goal);
                    }
                }
            }

        }
        protected void Update()
        {
            world.Update();
        }
        protected void Render()
        {
            Console.Clear();
            world.Render();
        }
        public void ProcessInput()
        {
            Input.Process();
        }

        public void Run()
        {
            while (IsRunning)
            {
                ProcessInput();
                Update();
                Render();
            }
        }

    }
}
