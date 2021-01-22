using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float delayTime = 1.0f;

    EnemyDamage enemyDamage;
    List<Waypoint> path;

    private void Awake()
    {
        enemyDamage = FindObjectOfType<EnemyDamage>();
        path = FindObjectOfType<Pathfinder>().GetPath();
    }

    void Start()
    {
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(delayTime);
        }

        enemyDamage.ProcessDeath(isDeath: false);
    }


}
