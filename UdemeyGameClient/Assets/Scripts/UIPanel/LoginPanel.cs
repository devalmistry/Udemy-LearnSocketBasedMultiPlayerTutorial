using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{

    private Button closeButton;

    private TMP_InputField usernameIF;
    private TMP_InputField passwordIF;
    private Button enterButton;
    private Button registerButton;

    private LoginRequest loginRequest;

    public override void OnEnter()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1,0.3f);
        transform.localPosition = new Vector3(1000, 0, 0);

        transform.DOLocalMove(Vector3.zero,0.5f);

        usernameIF = transform.Find("UserNameLabel/UserNameInput").GetComponent<TMP_InputField>();
        passwordIF = transform.Find("PasswordLabel/PasswordInput").GetComponent<TMP_InputField>();
        enterButton = transform.Find("EnterButton").GetComponent<Button>();
        registerButton = transform.Find("RegisterButton").GetComponent<Button>();

        enterButton.onClick.AddListener(OnEnterClick);
        registerButton.onClick.AddListener(OnRegisterClick);

        closeButton = transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(OnCloseClick);
        loginRequest = GetComponent<LoginRequest>();
    }


    private void OnEnterClick()
    {
        string msg = "";
        if (string.IsNullOrEmpty(usernameIF.text))
        {
            msg += "Please fill the username blank";
        }
        if (string.IsNullOrEmpty(passwordIF.text))
        {
            msg += "Please fill the Password blank";
        }

        if (msg!="")
        {
            uiMng.ShowMessage(msg);
            return;
        }

        loginRequest.SendRequest(usernameIF.text, passwordIF.text);
    }

    private void OnRegisterClick() {

    }



     private void OnCloseClick() {
        transform.DOScale(0, 0.3f);
        transform.DOLocalMove(new Vector3(1000, 0, 0),0.3f);
    }
}