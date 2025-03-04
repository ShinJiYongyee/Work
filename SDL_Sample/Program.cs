using SDL2;
using System;
using static SDL2.SDL;
namespace SDL_Sample
{
    internal class Program
    {
        public static void DrawCircle(IntPtr renderer, int centreX, int centreY, int radius)
        {
            int diameter = radius * 2;

            int x = (radius - 1);
            int y = 0;
            int tx = 1;
            int ty = 1;
            int error = (tx - diameter);

            while (x >= y)
            {
                // Each of the following renders an octant of the circle
                SDL_RenderDrawPoint(renderer, centreX + x, centreY - y);
                SDL_RenderDrawPoint(renderer, centreX + x, centreY + y);
                SDL_RenderDrawPoint(renderer, centreX - x, centreY - y);
                SDL_RenderDrawPoint(renderer, centreX - x, centreY + y);
                SDL_RenderDrawPoint(renderer, centreX + y, centreY - x);
                SDL_RenderDrawPoint(renderer, centreX + y, centreY + x);
                SDL_RenderDrawPoint(renderer, centreX - y, centreY - x);
                SDL_RenderDrawPoint(renderer, centreX - y, centreY + x);

                if (error <= 0)
                {
                    ++y;
                    error += ty;
                    ty += 2;
                }

                if (error > 0)
                {
                    --x;
                    tx += 2;
                    error += (tx - diameter);
                }
            }
        }
        static void Main(string[] args)
        {

            //엔진 초기화
            //HW의 모든 장치를 초기화
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("Fail Init");
            }

            //창 만들기
            //IntPtr 자료형으로 정수형 주소 저장
            IntPtr myWindow = SDL.SDL_CreateWindow(
                "Game",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            //엔진이 구동되는 동안 실행하는 부분

            //붓
            IntPtr myRenderer = SDL.SDL_CreateRenderer(myWindow, -1,
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE |
                SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

            //메세지 처리(사용자 처리가 추가 구조를 변경)
            SDL.SDL_Event myEvent;
            bool isRunning = true;
            Random random = new Random();
            while (isRunning)   //Event Loop == Game Loop
            {
                //매 프레임마다 메세지 유무를 확인 -> unity의 PeekMessage
                SDL.SDL_PollEvent(out myEvent);
                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false; break;       //창 닫기 버튼 누르면 창 닫기
                }

                //붓으로 윈도우 그리고 cpu에게 던져주기
                SDL.SDL_SetRenderDrawColor(myRenderer, 255, 255, 255, 0);
                SDL.SDL_RenderClear(myRenderer);

                //랜덤 색 정하기
                byte r = (byte)(random.Next() % 256);
                byte g = (byte)(random.Next() % 256);
                byte b = (byte)(random.Next() % 256);

                //원 좌표와 반지름 정하기
                int x = random.Next() % 640;
                int y = random.Next() % 480;
                int radius = random.Next() % 640;

                //원 그리기
                SDL.SDL_SetRenderDrawColor(myRenderer, r, g, b, 0);
                Program.DrawCircle(myRenderer, x, y, r);
                SDL.SDL_RenderPresent(myRenderer);

                ////원 그리기 2
                //SDL.SDL_SetRenderDrawColor(myRenderer, r, g, b, 0);
                //for (int i = 0; i < 360; i++)
                //{
                //    int x0 = (int)(radius * Math.Cos(i * (Math.PI / 180.0f)));
                //    int y0 = (int)(radius * Math.Sin(i * (Math.PI / 180.0f)));
                //    SDL.SDL_RenderDrawPoint(myRenderer, x + x0, y + y0);
                //}
                //SDL.SDL_RenderPresent(myRenderer);


            }

            //엔진 끄기
            //저장한 자료 제거
            SDL.SDL_DestroyWindow(myWindow);
            //시작한 SDL 끄기
            SDL.SDL_Quit();

        }
    }
}
