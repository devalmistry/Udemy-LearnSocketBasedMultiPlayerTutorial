using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{

    private Button closeButton;

    public override void OnEnter()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1,0.3f);
        transform.localPosition = new Vector3(1000, 0, 0);

        transform.DOLocalMove(Vector3.zero,0.5f);

        closeButton = transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(OnCloseClick);
    }

    private void OnCloseClick() {
        transform.DOScale(0, 0.3f);
        transform.DOLocalMove(new Vector3(1000, 0, 0),0.3f);
    }
}