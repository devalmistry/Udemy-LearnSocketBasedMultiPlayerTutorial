using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade)
    {

    }

    private Dictionary<RequestCode, BaseRequest> requestDict = new Dictionary<RequestCode, BaseRequest>();

    public void AddRequest(RequestCode requestCode, BaseRequest baseRequest)
    {

        requestDict.Add(requestCode, baseRequest);

    }
    public void RemoveRequest(RequestCode requestCode)
    {
        requestDict.Remove(requestCode);
    }


    public override void OnDestroy()
    {

    }

    public override void OnInit()
    {

    }
}