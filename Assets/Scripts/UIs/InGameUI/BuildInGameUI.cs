using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    public TowerPlace towerPlace;
    protected override void Awake()
    {
        base.Awake();

        // ���Ŀ(���)�� Ŭ���ϸ� ui�� �����Բ� �Ѵ�
        buttons["Blocker"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI(this); });
        // ��ó��ư�� ������ ��óŸ�� �Ǽ�, ĳ���ư�� ������ ĳ��Ÿ���� �Ǽ��ϰ� �Ѵ�
        buttons["ArcherButton"].onClick.AddListener(() => { BuildArcherTower(); });
        buttons["CanonButton"].onClick.AddListener(() => { BuildCanonTower(); });
    }

    public void BuildArcherTower()
    {
        // ���ӸŴ����� ���ҽ����� Data - ArcherTowerData ��η� Ÿ�������͸� �ҷ��´�
        TowerData archerTowerData = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        // Ÿ���÷��̽� Ŭ������ ����Ÿ�� �Լ��� ������ �����Ѵ�
        towerPlace.BuildTower(archerTowerData);
        // UI â�� �ݴ´�
        GameManager.UI.CloseInGameUI(this);
    }

    public void BuildCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        towerPlace.BuildTower(canonTowerData);
        GameManager.UI.CloseInGameUI(this);
    }
}
