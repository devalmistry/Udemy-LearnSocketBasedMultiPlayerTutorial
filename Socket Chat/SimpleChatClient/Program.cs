using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.29.220"),88));

            //Reading The Hello Message

            byte[] data = new byte[1024];
            int count = clientSocket.Receive(data);

            string msgReceive = Encoding.UTF8.GetString(data,0,count);

            Console.WriteLine(msgReceive);

            //Sending Message to the Server

            while (true)
            {
                string msgSend = Console.ReadLine();
                clientSocket.Send(Encoding.UTF8.GetBytes(msgSend));
            }

            Console.ReadKey();
            clientSocket.Close();
        }
    }
}
