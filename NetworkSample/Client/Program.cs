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

            byte[] buffer;

            string message = "Hello World";
            buffer = Encoding.UTF8.GetBytes(message);
            int sendLength = serverSocket.Send(buffer);

            byte[] buffer2 = new byte[1024];
            int receiveLength = serverSocket.Receive(buffer2);

            Console.WriteLine(Encoding.UTF8.GetString(buffer2));

            serverSocket.Close();

        }
    }
}
