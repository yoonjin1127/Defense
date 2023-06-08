using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData data;

    private void Awake()
    {
        // 경로에 있는 데이터를 호출
        data = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
    }
}
