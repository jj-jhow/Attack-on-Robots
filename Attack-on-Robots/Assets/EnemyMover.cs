using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints;
    [SerializeField] float delayTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowWaypoints());
    }

    IEnumerator FollowWaypoints()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            transform.position = waypoint.transform.position;
            print(waypoint.name);
            yield return new WaitForSeconds(delayTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
