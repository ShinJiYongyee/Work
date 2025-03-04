using SDL2;
namespace SDL_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //엔진 초기화
            //HW의 모든 장치를 초기화
            if( SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)  
            {
                Console.WriteLine("Fail Init");
            }

            //창 만들기
            //IntPtr 자료형으로 정수형 주소 저장
            IntPtr myWindow =  SDL.SDL_CreateWindow(
                "Game",
                100, 100, 
                640, 480, 
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            //메세지 처리(사용자 처리가 추가 구조를 변경)
            //엔진이 구동되는 동안 실행하는 부분
            while (true)
            {
                //매 프레임마다 메세지 유무를 확인 -> unity의 PeekMessage
                SDL.SDL_Event myEvent;
                SDL.SDL_PollEvent(out myEvent );    
            }

            //엔진 끄기
            //저장한 자료 제거
            SDL.SDL_DestroyWindow(myWindow);
            //시작한 SDL 끄기
            SDL.SDL_Quit();

        }
    }
}
