using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] EnemyMover enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnemyMover enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = this.transform;

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
