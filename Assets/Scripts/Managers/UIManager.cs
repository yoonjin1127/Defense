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

}