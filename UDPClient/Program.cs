using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UDP = 우리 집 문 앞에 던져둔 정보를 주워오는 서버
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 6000);

            //UDP는 정보를 쪼개서 받을 수 없으므로 한 번에 1024바이트 이상 받을 수 없다

            //보내기
            byte[] buffer = new byte[1024];
            string message = "안녕하세요";
            buffer = Encoding.UTF8.GetBytes(message);

            //별도의 연결 없이 보내기만 하면 된다
            int sendLength = serverSocket.SendTo(buffer, buffer.Length, SocketFlags.None, serverEndPoint);

            //받기
            //blocking 함수 = 정보를 받을 때까지 대기
            byte[] buffer2 = new byte[1024];
            EndPoint remoteEndPoint = serverEndPoint;
            int recvLength = serverSocket.ReceiveFrom(buffer2, ref remoteEndPoint);

            string message2 = Encoding.UTF8.GetString(buffer2);

            Console.WriteLine(message2);

            serverSocket.Close();
        }
    }
}
