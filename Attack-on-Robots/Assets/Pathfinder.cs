using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Waypoint[] waypoints;

    private void Awake()
    {
        waypoints = FindObjectsOfType<Waypoint>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPosition = waypoint.GetGridPosition();

            if (grid.ContainsKey(gridPosition))
            {
                Debug.LogWarning("Skipping overlapping block: " + waypoint);
            }
            else
            {
                grid.Add(gridPosition, waypoint);
            }
        }

        print("Loaded " + grid.Count + " blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
