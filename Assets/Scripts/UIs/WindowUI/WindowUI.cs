using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowUI : BaseUI, IDragHandler, IPointerDownHandler
{
    protected override void Awake()
    {
        base.Awake();

        buttons["CloseButton"].onClick.AddListener(() => { GameManager.UI.CloseWIndowUI(this); }) ;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 셀렉했을 때 나 자신을 선택
        GameManager.UI.SelectWindowUI(this);
    }
}
