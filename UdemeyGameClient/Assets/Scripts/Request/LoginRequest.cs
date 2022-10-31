using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class LoginRequest : BaseRequest
{
    private void Start()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
    }

    public void SendRequest(string userName, string password)
    {
        string data = userName + "," + password;
        base.SendRequest(data);
    }
}