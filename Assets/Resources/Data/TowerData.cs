using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TowerData", menuName = "Data/Tower")]
public class TowerData : ScriptableObject
{
    [SerializeField] TowerInfo[] towers;
    // 프로퍼티 이용
    public TowerInfo[] Towers { get { return towers; } }

    // 직렬화 가능한 클래스로 만들어서 배열을 생성
    [Serializable]
    public class TowerInfo
    {
        public Tower tower;

        public int damage;
        public float delay;
        public float range;

        public float buildTime;
        public int buildCost;
        public int sellCost;
    }

}

