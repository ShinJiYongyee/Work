using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Player : GameObject
    {
        public Player() 
        {
            this.X = 1;
            this.Y = 1;
            this.shape = 'P';
        }
        
        public override void RefreshPosition(ConsoleKey key)
        {
            if(key == ConsoleKey.W)
            {
                this.Y--;
            }
            if (key == ConsoleKey.A)
            {
                this.X--;
            }
            if (key == ConsoleKey.S)
            {
                this.Y++;
            }
            if (key == ConsoleKey.D)
            {
                this.X++;
            }
            this.ForcePosition();
        }


    }
}
