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

    private void Start()
    {
        clientManager = new ClientManager();
        audioManager = new AudioManager();
        playerManager = new PlayerManager();
        requestManager = new RequestManager();
        uIManager = new UIManager();
        cameraManager = new CameraManager();

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
}