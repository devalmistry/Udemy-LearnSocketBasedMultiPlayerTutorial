using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagePanel : BasePanel
{

    private TextMeshProUGUI text;

    private int showTime = 1;

    public override void OnEnter()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.enableCulling = false;
    }

    public void ShowMessage(string msg)
    {
        text.text = msg;
        text.enableCulling = true;
        Invoke("Hide", showTime);
    }

    private void Hide()
    {
        text.CrossFadeAlpha(0, 1, false);
    }

    public override void OnExit()
    {

    }
}