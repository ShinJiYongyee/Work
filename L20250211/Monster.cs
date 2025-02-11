using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Monster 
    {
        public Monster() 
        {
            Console.WriteLine("몬스터 생성자");
        }
        ~Monster() 
        {
            Console.WriteLine("몬스터 소멸자");
        }
        public int hp;
        public int gold;
        public void Attack() { }
        public void Die() { }

        //자식이 재정의할 수 있는 함수
        //부모 클래스로 선언, 접근 시 자식의 함수에 접근
        //다형성
        public virtual void Move()
        {
            Console.WriteLine("monster run");
        }
    }
}
