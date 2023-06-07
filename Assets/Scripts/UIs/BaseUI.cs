using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// UI ���ε�

public class BaseUI : MonoBehaviour
{
    protected Dictionary<string, RectTransform> transforms;
    protected Dictionary<string, Button> buttons;
    protected Dictionary<string, TMP_Text> texts;
    // TODO : add ui component

    // ���߿� �����ǰ� �ʿ��ϱ� ������ virtual�� ����
    protected virtual void Awake()
    {
        BindChildren();
    }

    private void BindChildren()
    {
        // �ʱ�ȭ���� ����
        transforms = new Dictionary<string, RectTransform>(); 
        buttons = new Dictionary<string, Button>();
        texts = new Dictionary<string, TMP_Text>();

        // ��� �ڽĵ��� ã�Ƴ�
        RectTransform[] children = GetComponentsInChildren<RectTransform>();
        foreach (RectTransform child in children) 
        {
            string key = child.gameObject.name;

            // key�� �����ϰ� �ִ� ��� �ѱ�
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
