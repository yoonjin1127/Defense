using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private void LateUpdate()
    {
        // 체력바가 카메라와 같은 방향으로 회전함
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
