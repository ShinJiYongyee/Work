﻿using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Client
{
    class Program
    {
        static Socket clientSocket;

        //메세지를 입력받고 보내는 함수
        static void ChatSend()
        {
            while (true)
            {
                string InputChat;
                Console.Write("채팅 : ");
                InputChat = Console.ReadLine();

                string jsonString = "{\"id\" : \"태규\",  \"message\" : \"" + InputChat + ".\"}";
                byte[] message = Encoding.UTF8.GetBytes(jsonString);
                ushort length = (ushort)message.Length;
                byte[] lengthBuffer = new byte[2];
                lengthBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)length));

                //[][][][][][][][][][][]
                byte[] buffer = new byte[2 + length];

                Buffer.BlockCopy(lengthBuffer, 0, buffer, 0, 2);
                Buffer.BlockCopy(message, 0, buffer, 2, length);

                int SendLength = clientSocket.Send(buffer, buffer.Length, SocketFlags.None);

            }


        }

        static void ChatRecv()
        {
            while (true)
            {

                byte[] lengthBuffer = new byte[2];
                ushort length = BitConverter.ToUInt16(lengthBuffer, 0);

                int RecvLength = clientSocket.Receive(lengthBuffer, 2, SocketFlags.None);
                length = BitConverter.ToUInt16(lengthBuffer, 0);
                length = (ushort)IPAddress.NetworkToHostOrder((short)length);
                byte[] recvBuffer = new byte[4096];
                RecvLength = clientSocket.Receive(recvBuffer, length, SocketFlags.None);

                string JsonString = Encoding.UTF8.GetString(recvBuffer);

                Console.WriteLine(JsonString);
            }
        }
        //[][]
        static void Main(string[] args)
        {

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

            clientSocket.Connect(listenEndPoint);

            Thread chatInputThread = new Thread(new ThreadStart(ChatSend));
            chatInputThread.IsBackground = true;
            chatInputThread.Start();

            Thread chatRecvThread = new Thread(new ThreadStart(ChatRecv));
            chatRecvThread.IsBackground = true;
            chatRecvThread.Start();

            chatInputThread.Join();
            chatRecvThread.Join();
            clientSocket.Close();
        }
    }
}