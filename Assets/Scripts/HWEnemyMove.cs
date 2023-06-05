using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HWEnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform endPoint;

    private void Awake()
    {
        // �׺�Ž� ������Ʈ �Ҵ�
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        // ���ӿ�����Ʈ�� ��������Ʈ �±׸� �ް� �ִ� ���� ã�� ����
        endPoint = GameObject.FindGameObjectWithTag("EndPoint2").transform;
        // ������Ʈ�� �������� ��������Ʈ�� ����
        agent.destination = endPoint.position;
    }

    private void Update()
    {
        // ������Ʈ�� ��������Ʈ���� 0.5f���� ����� ������ ��, �ı��Ѵ�
        if (Vector3.Distance(transform.position, endPoint.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
