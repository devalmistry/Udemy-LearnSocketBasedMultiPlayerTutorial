using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade)
    {

    }

    private Dictionary<ActionCode, BaseRequest> requestDict = new Dictionary<ActionCode, BaseRequest>();

    public void AddRequest(ActionCode actionCode, BaseRequest baseRequest)
    {

        requestDict.Add(actionCode, baseRequest);

    }
    public void RemoveRequest(ActionCode actionCode)
    {
        requestDict.Remove(actionCode);
    }


    public override void OnDestroy()
    {

    }

    public override void OnInit()
    {

    }

    public void HandleResponse(ActionCode actionCode, string data)
    {
        BaseRequest baseRequest = requestDict.TryGet<ActionCode, BaseRequest>(actionCode);
        baseRequest.OnResponse(data);
      
    }
}