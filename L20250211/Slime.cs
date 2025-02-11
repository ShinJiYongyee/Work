using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Slime : Monster
    {
        public Slime() 
        {
            Console.WriteLine("슬라임 생성자");
        }
        ~Slime() { }
        public int hp;
        public int gold;
        public void Attack() { }
        public void Die() { }
        public override void Move() 
        {
            Console.WriteLine("Slime slide");
        }

    }
}
