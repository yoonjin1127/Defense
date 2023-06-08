using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : BaseUI
{
    public Transform followTarget;
    // UI니까 벡터2
    public Vector2 followOffset;

    // 카메라 설정과 유사하므로 LateUpdate를 사용
    private void LateUpdate()
    {
        // 타깃이 비어있지 않을 때
        if (followTarget != null)
        {
            // 월드에서 스크린 위치로 대상을 따라다님
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }

    // 타겟 설정
    public void SetTarget(Transform target)
    {
        // 타겟을 추적
        this.followTarget = target;
        if (followTarget != null)
        {
            // 월드에서 스크린 위치로 대상을 따라다님
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }

    // 타겟과의 거리 설정
    public void SetOffset(Vector2 offset)
    {
        this.followOffset = offset;
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }
}
