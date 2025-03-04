using SDL2;
namespace SDL_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HW의 모든 장치를 초기화
            if( SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)  
            {
                Console.WriteLine("Fail Init");
            }

            //IntPtr 자료형으로 정수형 주소 저장
            IntPtr myWindow =  SDL.SDL_CreateWindow(
                "Game",
                100, 100, 
                640, 480, 
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            //저장한 자료 제거
            SDL.SDL_DestroyWindow(myWindow);

            //시작한 SDL 끄기
            SDL.SDL_Quit();

            //윈도우가 열렸다 사라지면 성공
        }
    }
}
