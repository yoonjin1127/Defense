using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 인터페이스를 추가하면, 이벤트 시스템이 자동으로 추가된다
public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler

// IPointerClickHandler는 클릭, 터치를 감지하는 이벤트를 제공하는 인터페이스이다
// IPointerEnterHandler 마우스 포인트가 특정 충돌범위 안에 들어올 때 발생하는 이벤트를 제공하는 인터페이스이다
// IPointerExitHandler  마우스 포인트가 특정 충돌범위 안에 나갈 때 발생하는 이벤트를 제공하는 인터페이스이다

// PointerEventData는 터치하고 있는 상태나 마우스를 클릭하고 있는 상황 (연속적으로 Input.GetKey() 상태를 유지하고 있을 때)에서 특정 액션을 취할 수 있게 해준다
{
    // 평소와 마우스 올렸을 때의 컬러를 각각 설정
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;

    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭했을 때 경로에 있는 UI창을 띄움
        BuildInGameUI buildUI = GameManager.UI.ShowInGameUI<BuildInGameUI>("UI/BuildInGameUI");
        // 타겟을 설정
        buildUI.SetTarget(transform);
        // 지금 위치
        buildUI.towerPlace = this;
    }
    // 마우스를 올렸을 때의 컬러
    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = onMouse;
    }
    // 마우스를 뗐을 때의 컬러
    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }

    public void BuildTower(TowerData data)
    {
        // TowerPlace 삭제
        GameManager.Resource.Destroy(gameObject);
        // 그 위치에 타워 생성
        GameManager.Resource.Instantiate(data.Towers[0].tower, transform.position, transform.rotation);
    }
}
