using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 인터페이스를 추가하면, 이벤트 시스템이 자동으로 추가된다
public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // 평소와 마우스 올렸을 때의 컬러를 각각 설정
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;

    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
        {
            Debug.Log("좌클릭됨");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("우클릭");
        }
    }
    // 마우스를 올렸을 때의 컬러
    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = onMouse;
    }
    // 마우스를 뗐을 때의 컬러
    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }
}
