using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// UI 바인딩

public class BaseUI : MonoBehaviour
{
    protected Dictionary<string, RectTransform> transforms;
    protected Dictionary<string, Button> buttons;
    protected Dictionary<string, TMP_Text> texts;
    // TODO : add ui component

    // 나중에 재정의가 필요하기 때문에 virtual로 설정
    protected virtual void Awake()
    {
        BindChildren();
    }

    private void BindChildren()
    {
        // 초기화부터 진행
        transforms = new Dictionary<string, RectTransform>(); 
        buttons = new Dictionary<string, Button>();
        texts = new Dictionary<string, TMP_Text>();

        // 모든 자식들을 찾아냄
        RectTransform[] children = GetComponentsInChildren<RectTransform>();
        foreach (RectTransform child in children) 
        {
            string key = child.gameObject.name;

            // key를 포함하고 있는 경우 넘김
            if (transforms.ContainsKey(key))
                continue;
            
            transforms.Add(key, child);

            Button button = child.GetComponent<Button>();
            if (button != null)
                buttons.Add(key, button);

            TMP_Text text = child.GetComponent<TMP_Text>();
            if (text != null)
                texts.Add(key, text);
        }
    }
}
