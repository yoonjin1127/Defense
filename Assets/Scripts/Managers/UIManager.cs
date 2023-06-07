using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    //�̱������� �ҰŸ� static ���̱�
    private EventSystem eventSystem;

    // �˾� UI���� �˾� ĵ������ �α�
    private Canvas popUpCanvas;

    // �˾� ���� ����
    private Stack<PopUpUI> popUpStack;

    private void Awake()
    {
        // �������ڸ��� �̺�Ʈ�ý����� �߰���
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        // �̺�Ʈ�ý����� UI�Ŵ����� �����ڽ����� ����
        eventSystem.transform.parent = transform;

        popUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popUpCanvas.gameObject.name = "PopUpCanvas";
        popUpCanvas.sortingOrder = 100;
        popUpStack = new Stack<PopUpUI>();
    }

    public T ShowPopUpUI<T>(T popUpUI) where T : PopUpUI
    {
        // �˾�â�� ������ �� ���� ui�� �Ⱥ��̰Բ�
        if (popUpStack.Count > 0)
        {
            PopUpUI prevUI = popUpStack.Peek();
            // �� ���� �˾�â ��Ȱ��ȭ
            prevUI.gameObject.SetActive(false);
        }

        T ui = GameManager.Pool.GetUI(popUpUI);
        ui.transform.SetParent(popUpCanvas.transform, false);

        popUpStack.Push(ui);

        // �Ͻ�����
        Time.timeScale = 0;

        // ���� �˾� ui�� ��ȯ
        return ui;
    }

    public T ShowPopUpUI<T>(string path) where T : PopUpUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowPopUpUI(ui);
    }

    public void ClosePopUPUI()
    {
        // ���� ���� �˾�â(�ֽ�)���� ������
        PopUpUI ui = popUpStack.Pop();
        // Ǯ�Ŵ����� ���� �ݳ�
        GameManager.Pool.ReleaseUI(ui.gameObject);

        // �ٽ� ������ UIâ Ȱ��ȭ
        if (popUpStack.Count > 0)
        {
            PopUpUI curUI = popUpStack.Peek();
            curUI.gameObject.SetActive(true);  
        }

        // �˾�â�� ����� ��� �Ͻ������� �����ؾ���
        if(popUpStack.Count == 0)
        {
            Time.timeScale = 1f;
        }
    }

}