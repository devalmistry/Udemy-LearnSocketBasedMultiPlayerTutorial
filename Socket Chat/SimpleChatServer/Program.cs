using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


namespace SimpleChatServer
{
    class Program
    {
        static Socket serverSocket, clientSocket;
        static IPEndPoint iPEndPoint;
        static IPAddress iPAddress;
        static int PORT = 88;


        static void Main(string[] args)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            iPAddress = IPAddress.Parse("192.168.29.220");
            iPEndPoint = new IPEndPoint(iPAddress, PORT);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(0);
            clientSocket = serverSocket.Accept();


            //Sending Message
            string msg = "Hello Client";
            byte[] Byte = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(Byte);


            //Read Message
            byte[] dataBuffer = new byte[1024];
            int count = clientSocket.Receive(dataBuffer);

            string msgReceive = Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine(msgReceive);

            Console.ReadKey();
            clientSocket.Close();
            serverSocket.Close();
        }
    }
}