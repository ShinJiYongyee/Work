using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250210
{
    public class World
    {
        public World() 
        {
            walls = new Wall[100];
            floors = new Floor[100];
            player = new Player();
            monsters = new Monster[10];
            goal = new Goal();
        }
        public Wall[] walls;

        public Floor[] floors;

        public Player player;

        public Monster[] monsters;

        public Goal goal;
    }
}
