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

    // ������ ĵ����
    private Canvas windowCanvas;

    // �ΰ��� ĵ����
    private Canvas inGameCanvas;

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

        windowCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        windowCanvas.gameObject.name = "WindowCanvas";
        windowCanvas.sortingOrder = 10;

        // gameSceneCanvas.sortingOrder = 1;

        inGameCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        inGameCanvas.gameObject.name = "InGameCanvas";
        inGameCanvas.sortingOrder = 0;

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

    public void ShowWindowUI(WindowUI windowUI)
    {
        WindowUI ui = GameManager.Pool.GetUI(windowUI);
        // ������� ��ġ�� �ƴ�, �ڽ��� ��ġ�� ��ġ�ϱ� ���� false�� ����
        ui.transform.SetParent(windowCanvas.transform, false);
    }

    public void ShowWindowUI(string path)
    {
        WindowUI ui = GameManager.Resource.Load<WindowUI>(path);
        ShowWindowUI(ui);
    }

    public void SelectWindowUI(WindowUI windowUI)
    {
        // ĵ���� ���� �����ڸ� ������Ʈ �߿��� ���� ���� �ö󰡴� ȿ��(������ ������ ����)
        windowUI.transform.SetAsLastSibling();
    }

    public void CloseWIndowUI(WindowUI windowUI)
    {
        GameManager.Pool.ReleaseUI(windowUI.gameObject);
    }

    public T ShowInGameUI<T>(T inGameUI) where T : InGameUI
    {
        T ui = GameManager.Pool.GetUI(inGameUI);
        ui.transform.SetParent(inGameCanvas.transform.transform, false);

        return ui;
    }

    public T ShowInGameUI<T>(string path) where T : InGameUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowInGameUI(ui);
    }

    public void CloseInGameUI<T>(T inGameUI) where T : InGameUI
    {
        GameManager.Pool.ReleaseUI(inGameUI.gameObject);
    }

}