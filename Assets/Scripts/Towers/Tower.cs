using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData data;

    private void Awake()
    {
        // ��ο� �ִ� �����͸� ȣ��
        data = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
    }
}
