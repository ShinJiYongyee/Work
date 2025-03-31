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

            List<Socket> clientSockets = new List<Socket>();
            List<Socket> checkRead = new List<Socket>();

            while (true)
            {
                checkRead.Clear();
                checkRead = new List<Socket>(clientSockets);
                checkRead.Add(listenSocket);

                //[listen]
                Socket.Select(checkRead, null, null, -1);

                foreach (Socket findsocket in checkRead)
                {
                    if(findsocket == listenSocket)
                    {
                        Socket clientSocket = listenSocket.Accept();
                        clientSockets.Add(clientSocket);
                        Console.WriteLine($"Connect client : {clientSocket.RemoteEndPoint}");
                    }
                    else
                    {
                        byte[] headBuffer = new byte[2];
                        int RecvLength = findsocket.Receive(headBuffer, 2, SocketFlags.None);
                        if (RecvLength > 0)
                        {
                            short packetLength = BitConverter.ToInt16(headBuffer, 0);
                            packetLength = IPAddress.NetworkToHostOrder(packetLength);

                            byte[] dataBuffer = new byte[4096];
                            RecvLength = findsocket.Receive(dataBuffer, packetLength, SocketFlags.None);
                            string JsonString = Encoding.UTF8.GetString(dataBuffer);
                            Console.WriteLine(JsonString);

                            string message = "{ \"message\" : \"클라이언트 받고 서버꺼 추가.\"}";
                            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                            ushort length =(ushort) IPAddress.HostToNetworkOrder(messageBuffer.Length);

                            headBuffer = BitConverter.GetBytes(length);

                            byte[] packetBuffer = new byte[headBuffer.Length + messageBuffer.Length];
                            Buffer.BlockCopy(headBuffer, 0, packetBuffer, 0, headBuffer.Length);
                            Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headBuffer.Length, messageBuffer.Length);
                            int SendLength = findsocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);
                        }
                        else
                        {
                            findsocket.Close();
                            clientSockets.Remove(findsocket);
                        }
                    }
                }
            }


        }
    }
}
