using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    // 네비게이션은 유니티 AI에 속해있음
    private NavMeshAgent agent;
    private Transform endPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
        agent.destination = endPoint.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
