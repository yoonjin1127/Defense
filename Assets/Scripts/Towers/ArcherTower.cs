using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    private void Awake()
    {
        data = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        
        // 스크립터블 오브젝트의 데이터를 바꿀 때는 조심해야 한다
        //data.towers[0].buildTime = 9999;
    }
}
