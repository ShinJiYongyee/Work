using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //소켓 클래스 인스턴스화
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //4000번 포트로 접속 받아오기
            //4000번 포트는 클라이언트 포트와의 접속을 통제하는 문지기 기능만을 수행
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, 4000);    //랜카드 내 아무 주소로나 받아오기
            //소켓과 포트 연결
            listenSocket.Bind(listenEndPoint);

            //통신 접속 시도(동시에 접속을 시도하는 클라이언트 대기줄 크기, 100이상 잡을 필요 없음)
            listenSocket.Listen(10);

            bool isRunning = true;
            while (isRunning)
            {
                //동기/blocking
                Socket clientSocket = listenSocket.Accept();   //클라이언트 입장

                byte[] buffer = new byte[1024];
                int receiveLength = clientSocket.Receive(buffer);    //클라이언트 소켓으로 받기, 길이를 반환
                if (receiveLength <= 0) //받은 정보 x
                {
                    //close
                    clientSocket.Close();

                    //error
                    isRunning = false;
                }

                int sendLength = clientSocket.Send(buffer);
                if (sendLength <= 0) //서버 끊김
                {
                    //close
                    clientSocket.Close();

                    //error
                    break;
                    isRunning = false;
                }

                clientSocket.Close(); //끊지 않으면 계속 연결하므로 다른 패킷이 포트를 사용할 수 없다

            }

            listenSocket.Close();
        }
    }
}
