using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // �е��̶� �׵θ��� ���� ������ ������ ���Ѵ�
    // ��, �����ڸ��� ���콺 Ŀ���� ���� �� �����̰Բ��ϴ� ��ǥ�̴�
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    [SerializeField] float padding;

    Vector3 moveDir;
    private float zoomScroll;

    private void OnEnable()
    {
        // ȭ�鿡 Ŀ���� �Ⱥ��̰� ����
        Cursor.lockState = CursorLockMode.Confined;   
    }

    private void OnDisable()
    {
        // ������� ���� ��, Ŀ���� ���̵��� ����
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate()
    {
        Move();
        // ī�޶�� LateUpdate
        Zoom();
    }

    private void Move()
    {
        // Ʈ�������� �̵�
        transform.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime, Space.World);   
    }

    private void OnPointer(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();

        // �е����� ���콺 Ŀ���� ���ʿ� ���� ��
        if (mousePos.x <= padding)
            moveDir.x = -1;
        // �е����� ���콺 Ŀ���� �����ʿ� ���� ��
        else if (mousePos.x >= Screen.width - padding) 
            moveDir.x = 1;
        // �� �̿��� ���
        else
            moveDir.x = 0;

        // �е����� ���콺 Ŀ���� �Ʒ��� ���� ��
        if (mousePos.y <= padding)
            moveDir.y = -1;
        // �е����� ���콺 Ŀ���� ���� ���� ��
        else if (mousePos.y >= Screen.height - padding)
            moveDir.y = 1;
        // �� �̿��� ���
        else
            moveDir.y = 0;
    }

    private void Zoom()
    {
        // �ڱ� �ڽ��� ��ġ�� �������, ����3 ���� ������ �ܽ�ũ�Ѹ�ŭ �̵�
        transform.Translate(Vector3.forward * zoomScroll * Time.deltaTime, Space.Self);
    }

    private void OnZoom(InputValue value) 
    {
        // �Է��� ����ŭ y��ǥ ����
        zoomScroll = value.Get<Vector2>().y; 
    }
}
