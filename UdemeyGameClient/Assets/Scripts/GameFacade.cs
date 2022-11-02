using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private ClientManager clientManager;
    private AudioManager audioManager;
    private PlayerManager playerManager;
    private RequestManager requestManager;
    private UIManager uIManager;
    private CameraManager cameraManager;

    private static GameFacade _instance;

    public static GameFacade Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    private void Start()
    { 
        InItManagers();
    }

    private void InItManagers()
    {
        clientManager = new ClientManager(this);
        playerManager = new PlayerManager(this);
        requestManager = new RequestManager(this);
        cameraManager = new CameraManager(this);
        uIManager = new UIManager(this);
        audioManager = new AudioManager(this);

        clientManager.OnInit();
        playerManager.OnInit();
        requestManager.OnInit();
        cameraManager.OnInit();
        uIManager.OnInit();
        audioManager.OnInit();
    }

    private void OnDestroy()
    {
        DestroyManagers();
    }

    private void DestroyManagers()
    {
        clientManager.OnDestroy();
        audioManager.OnDestroy();
        playerManager.OnDestroy();
        requestManager.OnDestroy();
        uIManager.OnDestroy();
        cameraManager.OnDestroy();
    }

    public void AddRequest(ActionCode actionCode, BaseRequest baseRequest)
    {
        requestManager.AddRequest(actionCode, baseRequest);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        requestManager.RemoveRequest(actionCode);
    }

    public void HandleResponse(ActionCode actionCode, string data)
    {
        requestManager.HandleResponse(actionCode, data);
    }

    public void ShowMessage(string msg)
    {
        uIManager.ShowMessage(msg);
    }

    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        clientManager.SendRequest(requestCode, actionCode, data);
    }
}