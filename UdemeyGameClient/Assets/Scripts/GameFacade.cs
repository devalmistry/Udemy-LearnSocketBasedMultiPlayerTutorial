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
        clientManager = new ClientManager(this);
        audioManager = new AudioManager(this);
        playerManager = new PlayerManager(this);
        requestManager = new RequestManager(this);
        uIManager = new UIManager(this);
        cameraManager = new CameraManager(this);

        InItManagers();
    }

    private void InItManagers()
    {
        clientManager.OnInit();
        audioManager.OnInit();
        playerManager.OnInit();
        requestManager.OnInit();
        uIManager.OnInit();
        cameraManager.OnInit();
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

    public void AddRequest(RequestCode requestCode, BaseRequest baseRequest)
    {
        requestManager.AddRequest(requestCode, baseRequest);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        requestManager.RemoveRequest(requestCode);
    }

    public void HandleResponse(RequestCode requestCode, string data) {
        requestManager.HandleResponse(requestCode, data);
    }

    public void ShowMessage(string msg) {
        uIManager.ShowMessage(msg);
    }
}