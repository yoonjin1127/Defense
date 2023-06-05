using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// �������̽��� �߰��ϸ�, �̺�Ʈ �ý����� �ڵ����� �߰��ȴ�
public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // ��ҿ� ���콺 �÷��� ���� �÷��� ���� ����
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
            Debug.Log("��Ŭ����");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("��Ŭ��");
        }
    }
    // ���콺�� �÷��� ���� �÷�
    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = onMouse;
    }
    // ���콺�� ���� ���� �÷�
    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }
}
