using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileServer
{
    internal class Program
    {
        static async Task Main()
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, 4000);

            listenSocket.Bind(listenEndPoint);

            listenSocket.Listen(10);

            Socket clientSocket = listenSocket.Accept();

            FileStream fsInput = new FileStream("1.webp", FileMode.Open);

            byte[] buffer = new byte[1024];

            int readSize = 0;
            do
            {
                readSize = fsInput.Read(buffer, 0, 1);
                int SendSize = clientSocket.Send(buffer, readSize, SocketFlags.None);

            } while (readSize > 0);

            fsInput.Close();
            clientSocket.Close();
            listenSocket.Close();

        }
    }
}

