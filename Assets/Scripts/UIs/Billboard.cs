using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private void LateUpdate()
    {
        // ü�¹ٰ� ī�޶�� ���� �������� ȸ����
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
