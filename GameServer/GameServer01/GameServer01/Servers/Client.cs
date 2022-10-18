﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common;

namespace GameServer01.Servers
{
    class Client
    {
        private Socket clientSocket;
        private Server server;
        private Message msg = new Message(); 

        public Client(Socket clientSocket, Server server)
        {
            this.clientSocket = clientSocket;
            this.server = server;
        }

        public void start()
        {
            clientSocket.BeginReceive(msg.Data, msg.StartIndex,msg.RemainSize, SocketFlags.None, ReceiveCallBack, null);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            int count = clientSocket.EndReceive(ar);
            if (count==0)
            {
                Close();
            }
            msg.ReadMessge(count, OnProcessMessage);
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


        public void OnProcessMessage(RequestCode requestCode, ActionCode actionCode, string data )
        {
            server.HandleRequest(requestCode, actionCode, data, this);
        }
    }
}