using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace GameServer01.Server
{
    class Client
    {
        private Socket clientSocket;
        private Server server;

        public Client(Socket clientSocket, Server server)
        {
            this.clientSocket = clientSocket;
            this.server = server;
        }

        public void start()
        {
            clientSocket.BeginReceive(null, 0, 0, SocketFlags.None, ReceiveCallBack, null);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            int count = clientSocket.EndReceive(ar);
            if (count==0)
            {
                Close();
            }
            start();
        }

        private void Close()
        {
            if (clientSocket!=null)
            {
                clientSocket.Close();
            }
            server.RemoveClient(this);
        }
    }
}
