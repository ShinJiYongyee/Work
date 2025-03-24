using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L20250324_Thread
{
    internal class Program
    {

        volatile static int Money = 0;

        static SpinLock spinLock = new SpinLock();

        static bool lockTaken = false;

        static Object _lock1 = new Object(); //작업공간 열쇠
        static Object _lock2 = new Object(); //작업공간 열쇠

        static void Add()
        {
            for (int i = 0; i < 100000000; i++)
            {
                lock (_lock1)
                {
                    lock (_lock2)
                    {
                        Money++;
                    }

                }
            }
        }

        static void Remove()
        {
            for (int i = 0; i < 100000000; i++)
            {
                lock (_lock2)
                {
                    lock (_lock1)
                    {
                        Money--;
                    }

                }
            }
        }

        //UI Thread, 화면 그리기
        static void Main(string[] args)
        {
            //쓰레드 등록: 새 함수를 실행하도록 등록

            //OS에게 B함수 등록 지시
            Thread thread1 = new Thread(new ThreadStart(Add));
            Thread thread2 = new Thread(new ThreadStart(Remove));

            //B함수를 따로 실행(Thread)하도록 OS에게 지시

            //쓰레드의 결과를 화면에 그리지 않음
            //foreground: main thread 종료시 나머지 쓰레드는 다 종료
            thread1.IsBackground = true;
            thread1.Start();
            thread2.IsBackground = true;
            thread2.Start();

            //thread 종료 시까지 대기
            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Money : {Money}");

        }
    }
}
