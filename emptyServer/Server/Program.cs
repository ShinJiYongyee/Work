using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Message
    {
        public string message;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, 4000);

            listenSocket.Bind(listenEndPoint);

            listenSocket.Listen(10);

            Socket clientSocket = listenSocket.Accept();

            byte[] headerBuffer = new byte[2];

            int RecvLength = clientSocket.Receive(headerBuffer, 2, SocketFlags.None);
     
            short packetlength = BitConverter.ToInt16(headerBuffer, 0);
            packetlength =IPAddress.NetworkToHostOrder(packetlength);

            byte[] dataBuffer = new byte[4096];
            RecvLength = clientSocket.Receive(dataBuffer, packetlength, SocketFlags.None);

            string JsonString = Encoding.UTF8.GetString(dataBuffer, 0, RecvLength);

            Console.WriteLine(JsonString);

            string message = "{\"message\" : \"클라이언트 받고 서버 데이터 추가\"}";
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            ushort length =(ushort) IPAddress.HostToNetworkOrder(messageBuffer.Length);

            headerBuffer = BitConverter.GetBytes(length);

            byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];

            Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
            Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);

            int sendLength = clientSocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);

            clientSocket.Close();
            listenSocket.Close();
        }
    }
}
