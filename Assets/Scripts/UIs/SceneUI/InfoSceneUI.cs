using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoSceneUI : SceneUI
{
    public TMP_Text heartText;

    protected override void Awake()
    {
        // 부모 호출
        base.Awake();

        // 시작하자마자 텍스트 중 "HeartText"를 찾아서 넣기
        /* heartText = texts["HeartText"];
        heartText.text = 10.ToString(); */

        texts["HeartText"].text = "20";
        texts["CoinText"].text = "100";
    }
}
