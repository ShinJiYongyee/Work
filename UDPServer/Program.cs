using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UDP = 우리 집 문 앞에 던져둔 정보를 주워오는 서버
            //(ip주소를 갖는)컴퓨터:아파트, port:집 호수
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 6000);

            //우리 집 앞 위치를 bind
            serverSocket.Bind(serverEndPoint);

            //UDP는 정보를 쪼개서 받을 수 없으므로 한 번에 1024바이트 이상 받을 수 없다
            byte[] buffer = new byte[1024];
            EndPoint clientEndPoint = (EndPoint)serverEndPoint;

            //blocking 함수 = 정보를 받을 때까지 대기
            int recvLength = serverSocket.ReceiveFrom(buffer, ref clientEndPoint);

            int sendLength = serverSocket.SendTo(buffer, clientEndPoint);

            serverSocket.Close();

        }
    }
}
