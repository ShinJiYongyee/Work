using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
        }
        public override void Update()
        {

            if (Input.GetKeyDown(ConsoleKey.W))
            {
                Y--;
            }
            if (Input.GetKeyDown(ConsoleKey.S))
            {
                Y++;
            }
            if (Input.GetKeyDown(ConsoleKey.A))
            {
                X--;
            }
            if (Input.GetKeyDown(ConsoleKey.D))
            {
                X++;
            }
        }
    }
}
