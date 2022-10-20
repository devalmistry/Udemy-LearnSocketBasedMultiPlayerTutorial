using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Common;
public class ClientManager : BaseManager
{

    private const string IP = "127.0.0.1";
    private const int PORT = 6688;
    Socket clientSocket;
    Message msg = new Message();

    public ClientManager(GameFacade facade) : base(facade)
    {

    }

    public override void OnInit()
    {
        try
        {
            Start();
            clientSocket.Close();
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
    }

    private void Start()
    {
        clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReciveCallback, null);
    }

    private void ReciveCallback(IAsyncResult ar)
    {
        int count = clientSocket.EndReceive(ar);
        msg.ReadMessge(count, OnProcessDataCallback);    
    }

    private void OnProcessDataCallback(RequestCode requestCode,string Data) {

    }

    public override void OnDestroy()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
    }
    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        byte[] bytes = Message.PackData(requestCode, actionCode, data);
        clientSocket.Send(bytes);
    }
}