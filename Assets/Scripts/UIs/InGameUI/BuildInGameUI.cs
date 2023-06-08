using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    public TowerPlace towerPlace;
    protected override void Awake()
    {
        base.Awake();

        // 블로커(허공)를 클릭하면 ui가 닫히게끔 한다
        buttons["Blocker"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI(this); });
        // 아처버튼을 누르면 아처타워 건설, 캐논버튼을 누르면 캐논타워를 건설하게 한다
        buttons["ArcherButton"].onClick.AddListener(() => { BuildArcherTower(); });
        buttons["CanonButton"].onClick.AddListener(() => { BuildCanonTower(); });
    }

    public void BuildArcherTower()
    {
        // 게임매니저의 리소스에서 Data - ArcherTowerData 경로로 타워데이터를 불러온다
        TowerData archerTowerData = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        // 타워플레이스 클래스의 빌드타워 함수를 가져와 실행한다
        towerPlace.BuildTower(archerTowerData);
        // UI 창을 닫는다
        GameManager.UI.CloseInGameUI(this);
    }

    public void BuildCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        towerPlace.BuildTower(canonTowerData);
        GameManager.UI.CloseInGameUI(this);
    }
}
