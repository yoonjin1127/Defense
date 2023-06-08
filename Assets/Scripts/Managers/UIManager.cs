using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    //싱글톤으로 할거면 static 붙이기
    private EventSystem eventSystem;

    // 팝업 UI들은 팝업 캔버스에 두기
    private Canvas popUpCanvas;

    // 팝업 관리 스택
    private Stack<PopUpUI> popUpStack;

    // 윈도우 캔버스
    private Canvas windowCanvas;

    // 인게임 캔버스
    private Canvas inGameCanvas;

    private void Awake()
    {
        // 시작하자마자 이벤트시스템이 추가됨
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        // 이벤트시스템을 UI매니저의 하위자식으로 설정
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
        // 팝업창을 열었을 때 이전 ui가 안보이게끔
        if (popUpStack.Count > 0)
        {
            PopUpUI prevUI = popUpStack.Peek();
            // 맨 위의 팝업창 비활성화
            prevUI.gameObject.SetActive(false);
        }

        T ui = GameManager.Pool.GetUI(popUpUI);
        ui.transform.SetParent(popUpCanvas.transform, false);

        popUpStack.Push(ui);

        // 일시정지
        Time.timeScale = 0;

        // 만든 팝업 ui를 반환
        return ui;
    }

    public T ShowPopUpUI<T>(string path) where T : PopUpUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowPopUpUI(ui);
    }

    public void ClosePopUPUI()
    {
        // 가장 위의 팝업창(최신)부터 닫힌다
        PopUpUI ui = popUpStack.Pop();
        // 풀매니저를 통해 반납
        GameManager.Pool.ReleaseUI(ui.gameObject);

        // 다시 맨위의 UI창 활성화
        if (popUpStack.Count > 0)
        {
            PopUpUI curUI = popUpStack.Peek();
            curUI.gameObject.SetActive(true);  
        }

        // 팝업창이 사라질 경우 일시정지를 해제해야함
        if(popUpStack.Count == 0)
        {
            Time.timeScale = 1f;
        }
    }

    public void ShowWindowUI(WindowUI windowUI)
    {
        WindowUI ui = GameManager.Pool.GetUI(windowUI);
        // 월드상의 위치가 아닌, 자신의 위치를 유치하기 위해 false로 설정
        ui.transform.SetParent(windowCanvas.transform, false);
    }

    public void ShowWindowUI(string path)
    {
        WindowUI ui = GameManager.Resource.Load<WindowUI>(path);
        ShowWindowUI(ui);
    }

    public void SelectWindowUI(WindowUI windowUI)
    {
        // 캔버스 상의 형제자매 오브젝트 중에서 제일 위로 올라가는 효과(마지막 순위로 변경)
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