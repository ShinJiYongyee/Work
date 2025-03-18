using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static async Task Main()
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Loopback, 4000);

            clientSocket.Connect(listenEndPoint); //알아서 클라이언트 소켓 - 서버 소켓 연결

            //보내기
            string sendedJsonString = "{\"message\" : \"안녕하세요\"}"; //json은 문자열 형태로 보낼 수 있다
            byte[] message = Encoding.UTF8.GetBytes(sendedJsonString);
            int sendLenghth = clientSocket.Send(message);

            //받기
            byte[] buffer = new byte[1024];
            int receiveLength = clientSocket.Receive(buffer);
            string receivedJsonString = Encoding.UTF8.GetString(buffer);

            Console.WriteLine(receivedJsonString);

            clientSocket.Close();

        }
    }
}
