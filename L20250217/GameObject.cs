﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class GameObject
    {
        public int X, Y;
        public char Shape;  //Mesh, Sprite

        public virtual void Update()
        {

        }
        public virtual void Render()
        {
            //X, Y 위치에 Shape 출력
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(Shape);

        }

    }
}
