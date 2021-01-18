using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float delayTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        List<Waypoint> path = FindObjectOfType<Pathfinder>().GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(delayTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
