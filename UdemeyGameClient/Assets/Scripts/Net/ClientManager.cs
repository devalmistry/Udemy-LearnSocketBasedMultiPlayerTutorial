using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ClientManager : BaseManager
{

    private const string IP = "127.0.0.1";
    private const int PORT = 6688;
    Socket clientSocket;


    public override void OnDestroy()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
        }
        catch (Exception e)
        {

            Debug.Log (e);
        }
    }

    public override void OnInit()
    {
        try
        {
            clientSocket.Close();
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
    }
}