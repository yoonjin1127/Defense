using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : BaseUI
{
    public Transform followTarget;
    // UI�ϱ� ����2
    public Vector2 followOffset;

    // ī�޶� ������ �����ϹǷ� LateUpdate�� ���
    private void LateUpdate()
    {
        // Ÿ���� ������� ���� ��
        if (followTarget != null)
        {
            // ���忡�� ��ũ�� ��ġ�� ����� ����ٴ�
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }

    // Ÿ�� ����
    public void SetTarget(Transform target)
    {
        // Ÿ���� ����
        this.followTarget = target;
        if (followTarget != null)
        {
            // ���忡�� ��ũ�� ��ġ�� ����� ����ٴ�
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }

    // Ÿ�ٰ��� �Ÿ� ����
    public void SetOffset(Vector2 offset)
    {
        this.followOffset = offset;
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }
}
