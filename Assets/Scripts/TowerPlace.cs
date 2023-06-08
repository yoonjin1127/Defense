using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// �������̽��� �߰��ϸ�, �̺�Ʈ �ý����� �ڵ����� �߰��ȴ�
public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler

// IPointerClickHandler�� Ŭ��, ��ġ�� �����ϴ� �̺�Ʈ�� �����ϴ� �������̽��̴�
// IPointerEnterHandler ���콺 ����Ʈ�� Ư�� �浹���� �ȿ� ���� �� �߻��ϴ� �̺�Ʈ�� �����ϴ� �������̽��̴�
// IPointerExitHandler  ���콺 ����Ʈ�� Ư�� �浹���� �ȿ� ���� �� �߻��ϴ� �̺�Ʈ�� �����ϴ� �������̽��̴�

// PointerEventData�� ��ġ�ϰ� �ִ� ���³� ���콺�� Ŭ���ϰ� �ִ� ��Ȳ (���������� Input.GetKey() ���¸� �����ϰ� ���� ��)���� Ư�� �׼��� ���� �� �ְ� ���ش�
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
        // Ŭ������ �� ��ο� �ִ� UIâ�� ���
        BuildInGameUI buildUI = GameManager.UI.ShowInGameUI<BuildInGameUI>("UI/BuildInGameUI");
        // Ÿ���� ����
        buildUI.SetTarget(transform);
        // ���� ��ġ
        buildUI.towerPlace = this;
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

    public void BuildTower(TowerData data)
    {
        // TowerPlace ����
        GameManager.Resource.Destroy(gameObject);
        // �� ��ġ�� Ÿ�� ����
        GameManager.Resource.Instantiate(data.Towers[0].tower, transform.position, transform.rotation);
    }
}
