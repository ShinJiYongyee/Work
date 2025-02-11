using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Player : Character
    {
        public Player() 
        {
            Hp = 100;
            gold = -10;
            Console.WriteLine("플레이어 생성자");
        }
        public Player(int inHp, int inGold)
        {
            Hp=inHp;
            gold=inGold;
        }
        ~Player() 
        {
            Console.WriteLine("플레이어 소멸자");
        }
        public int Hp 
        {
            get; set;
        }

        public int gold;

        public void Attack() { }
        public void Move() 
        {
            Console.WriteLine("player run");
        }
        public void Collect() { }
        public void Die() { }
    }
}
