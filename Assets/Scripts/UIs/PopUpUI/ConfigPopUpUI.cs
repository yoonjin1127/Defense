using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["SaveButton"].onClick.AddListener(() => {  GameManager.UI.ClosePopUPUI(); });
        buttons["CancleButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUPUI(); });
    }
}
