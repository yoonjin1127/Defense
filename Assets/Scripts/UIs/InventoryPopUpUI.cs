using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Exit"].onClick.AddListener(() => { GameManager.UI.ClosePopUPUI(); });    
    }
}
