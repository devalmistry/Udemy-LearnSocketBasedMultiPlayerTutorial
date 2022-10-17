using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace GameServer01.Server
{
    class Server
    {
        private IPEndPoint iPEndPoint;
        Socket serverSocket;

        private List<Client> clientList = new List<Client>();

        public Server(String ipStr, int port)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Parse(ipStr), port);
        }

        public void Start() {
              serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallBack,null);
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket clientSocket = serverSocket.EndAccept(ar);
            Client client = new Client(clientSocket, this);

            clientList.Add(client);
        }

        public void RemoveClient(Client client) {
            lock (clientList) {
                clientList.Remove(client);
            }
        }
    }
}