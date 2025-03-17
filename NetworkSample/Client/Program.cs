using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Loopback: 자기 자신, 127.0.0.1과 동일
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 4000); 
            //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000); 
            serverSocket.Connect(serverEndPoint);

            //계산할 문제
            string message = "100+200";

            //문제 보내기
            byte[] sendBuffer = new byte[1024];
            sendBuffer = Encoding.UTF8.GetBytes(message);
            int sendLength = serverSocket.Send(sendBuffer);
            if (sendLength < sendBuffer.Length)
            {
                sendLength = serverSocket.Send(sendBuffer);
            }
            if (sendLength != 0)
            {
                Console.WriteLine("보내기");

            }

            //결과 받아오기
            byte[] receiveBuffer = new byte[1024];
            int receiveLength = serverSocket.Receive(receiveBuffer);
            if (receiveLength < receiveBuffer.Length) 
            { 
                receiveLength = receiveBuffer.Length; 
            }
            if(receiveLength != 0)
            {
                Console.WriteLine("받기");

            }

            Console.WriteLine(Encoding.UTF8.GetString(receiveBuffer));

            serverSocket.Close();

        }
    }
}
