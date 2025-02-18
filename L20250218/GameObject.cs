using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class GameObject
    {
        public GameObject() { }

        public int X;
        public int Y;
        public char shape;

        public virtual void RefreshPosition(ConsoleKey key)
        {

        }
        public void ForcePosition()
        {
            if (X<=0)
            {
                X = 1;
            }
            if (Y<=0)
            {
                Y = 1;
            }
            if (X >= 9)
            {
                X = 8;
            }
            if (Y >= 9)
            {
                Y = 8;
            }
        }

    }
}
