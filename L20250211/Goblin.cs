using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Goblin : Monster
    {
        public Goblin() { }
        ~Goblin() { }
        public int hp;
        public int gold;
        public void Attack() { }
        public void Die() { }
        public void Move() 
        {
            Console.WriteLine("goblin walk");
        }
    }
}
