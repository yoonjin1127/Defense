using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnTime;
    [SerializeField] GameObject enemyPrefab;

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    // 반복해서 스폰포인트에 적을 생성하는 스폰루틴
    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
