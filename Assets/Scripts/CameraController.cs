using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // 패딩이란 테두리와 내용 사이의 간격을 뜻한다
    // 즉, 가장자리에 마우스 커서를 뒀을 때 움직이게끔하는 지표이다
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    [SerializeField] float padding;

    Vector3 moveDir;
    private float zoomScroll;

    private void OnEnable()
    {
        // 화면에 커서를 안보이게 설정
        Cursor.lockState = CursorLockMode.Confined;   
    }

    private void OnDisable()
    {
        // 사용하지 않을 때, 커서가 보이도록 설정
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate()
    {
        Move();
        // 카메라는 LateUpdate
        Zoom();
    }

    private void Move()
    {
        // 트랜스폼의 이동
        transform.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime, Space.World);   
    }

    private void OnPointer(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();

        // 패딩보다 마우스 커서가 왼쪽에 있을 때
        if (mousePos.x <= padding)
            moveDir.x = -1;
        // 패딩보다 마우스 커서가 오른쪽에 있을 때
        else if (mousePos.x >= Screen.width - padding) 
            moveDir.x = 1;
        // 그 이외의 경우
        else
            moveDir.x = 0;

        // 패딩보다 마우스 커서가 아래에 있을 때
        if (mousePos.y <= padding)
            moveDir.y = -1;
        // 패딩보다 마우스 커서가 위에 있을 때
        else if (mousePos.y >= Screen.height - padding)
            moveDir.y = 1;
        // 그 이외의 경우
        else
            moveDir.y = 0;
    }

    private void Zoom()
    {
        // 자기 자신의 위치와 상관없이, 벡터3 기준 앞으로 줌스크롤만큼 이동
        transform.Translate(Vector3.forward * zoomScroll * Time.deltaTime, Space.Self);
    }

    private void OnZoom(InputValue value) 
    {
        // 입력한 값만큼 y좌표 변동
        zoomScroll = value.Get<Vector2>().y; 
    }
}
