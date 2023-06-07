using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        // buttons["InfoButton"].onClick.AddListener(ClickInfoButton);
        buttons["InfoButton"].onClick.AddListener(() => { Debug.Log("Info");});
        buttons["VolumeButton"].onClick.AddListener(() => { Debug.Log("Volume"); });
        buttons["SettingButton"].onClick.AddListener(() => { OpenPausePopUpUI();});
        buttons["InventoryButton"].onClick.AddListener(() => { OpenInventory(); });
    }

    public void OpenPausePopUpUI()
    {
        // 경로로 열기
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/SettingPopUpUI");
    }

    public void OpenInventory()
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/InventoryPopUpUI");
    }

    /* public void ClickInfoButton()
    {

    }*/
}
