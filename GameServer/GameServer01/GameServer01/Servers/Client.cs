using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common;
using MySql.Data.MySqlClient;
using GameServer01.Tool;

namespace GameServer01.Servers
{
    class Client
    {

        private Socket clientSocket;
        private Server server;
        private Message msg = new Message();
    
        private MySqlConnection mySqlConn;

        public MySqlConnection MySqlConn {
            get { return mySqlConn; }
        }

        public Client(Socket clientSocket, Server server)
        {
            this.clientSocket = clientSocket;
            this.server = server;
            this.mySqlConn = ConnHelper.Connect();
        }

        public void Send(ActionCode actionCode, string data)
        {
            byte[] bytes = Message.PackData(actionCode, data);
            clientSocket.Send(bytes);
        }

        public void start()
        {
            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, null);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            int count = clientSocket.EndReceive(ar);
            if (count == 0)
            {
                Close();
            }
            msg.ReadMessge(count, OnProcessMessage);
            start();
        }

        private void Close()
        {
            ConnHelper.CloseConnection(mySqlConn);
            if (clientSocket != null)
            {
                clientSocket.Close();
            }
            server.RemoveClient(this);
        }


        public void OnProcessMessage(RequestCode requestCode, ActionCode actionCode, string data)
        {
            server.HandleRequest(requestCode, actionCode, data, this);
        }
    }
}