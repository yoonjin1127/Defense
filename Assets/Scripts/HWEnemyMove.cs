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
        // 네비매쉬 에이전트 할당
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        // 게임오브젝트중 엔드포인트 태그를 달고 있는 것을 찾아 대입
        endPoint = GameObject.FindGameObjectWithTag("EndPoint2").transform;
        // 에이전트의 목적지를 엔드포인트로 설정
        agent.destination = endPoint.position;
    }

    private void Update()
    {
        // 에이전트가 엔드포인트까지 0.5f만을 남기고 접근할 시, 파괴한다
        if (Vector3.Distance(transform.position, endPoint.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
