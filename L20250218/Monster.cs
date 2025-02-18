using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Monster : GameObject
    {
        Random rand = new Random();
        public Monster()
        {
            this.X = 4;
            this.Y = 6;
            this.shape = 'M';
        }
        public override void RefreshPosition(ConsoleKey key)
        {
            int a = rand.Next();
            if (a % 4 == 0)
            {
                this.Y--;
            }
            if (a % 4 == 1)
            {
                this.X--;
            }
            if (a % 4 == 2)
            {
                this.Y++;
            }
            if (a % 4 == 3)
            {
                this.X++;
            }
            this.ForcePosition();
        }
    }
}
