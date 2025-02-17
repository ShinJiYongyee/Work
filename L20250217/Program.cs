namespace L20250217
{
    internal class Program
    {
        /// <summary>
        /// 1번만 부를 수 있는 클래스, 재차 호출시 기존 인스턴스를 활용한다
        /// </summary>
        class Singleton()
        {

            static Singleton instance;
            static public Singleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }

            static public Singleton GetInstance()
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        static void Main(string[] args)
        {

            Engine engine = Engine.Instance;

            engine.Load();  //월드 로드

            engine.Run();

            
        }
    }
}
