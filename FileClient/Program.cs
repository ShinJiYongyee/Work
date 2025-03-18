using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

//프로젝트 폴더와 솔루션을 같은 폴더에 배치
namespace FileClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

            clientSocket.Connect(listenEndPoint); //알아서 클라이언트 소켓 - 서버 소켓 연결

            FileStream fsOutput = new FileStream("1_copy.webp", FileMode.CreateNew);


            int receiveLength = 0;
            do
            {
                byte[] buffer = new byte[1024];
                receiveLength = clientSocket.Receive(buffer);
                fsOutput.Write(buffer, 0, receiveLength);


            } while (receiveLength > 0);

            fsOutput.Close();
            clientSocket.Close();

        }
    }
}
