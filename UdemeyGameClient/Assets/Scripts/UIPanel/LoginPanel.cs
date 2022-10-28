using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel : BasePanel
{
    public override void OnEnter()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1,0.3f);
        transform.localPosition = new Vector3(1000, 0, 0);

        transform.DOLocalMove(Vector3.zero,0.5f);
    }
}