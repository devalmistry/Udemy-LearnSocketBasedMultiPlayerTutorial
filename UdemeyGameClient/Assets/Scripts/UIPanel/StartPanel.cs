using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private Button loginButton;



    public override void OnEnter()
    {
        loginButton = transform.Find("LoginButton").GetComponent<Button>();

        loginButton.onClick.AddListener(OnLoginClick);
    }
    private void OnLoginClick() {
        uiMng.PushPanel(UIPanelType.Login);

    }
}
