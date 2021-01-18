using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private Waypoint searchCenter;
    private Waypoint[] waypoints;
    
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private List<Waypoint> dequeuedList = new List<Waypoint>();
    private List<Waypoint> path = new List<Waypoint>();

    private Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        SearchPath();
        CreatePath();
        return path;
    }

    private void Awake()
    {
        waypoints = FindObjectsOfType<Waypoint>();
    }

    private void Start()
    {
        
    }

    private void SearchPath()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0)
        {
            searchCenter = queue.Dequeue();
            dequeuedList.Add(searchCenter);

            if (searchCenter == endWaypoint)
            {
                queue.Clear();
                dequeuedList.Clear();
                break;
            }
            ExplorNeighbors();
        }
    }

    private void CreatePath()
    {
        Waypoint breadcrumb = endWaypoint;

        while (breadcrumb.exploredFrom || breadcrumb == startWaypoint)
        {
            path.Add(breadcrumb);
            
            if (!breadcrumb.exploredFrom)
                break;
            
            breadcrumb = breadcrumb.exploredFrom;

            if (breadcrumb != startWaypoint && breadcrumb != endWaypoint)
                breadcrumb.SetTopColor(Color.cyan);
        }

        path.Reverse();

        foreach (var item in path) // Todo: Remove
        {
            print(item);
        }
    }

    private void ExplorNeighbors()
    {
        Vector2Int neighborPosition;
        Waypoint neighbor;

        foreach (Vector2Int direction in directions)
        {
            neighborPosition = searchCenter.GetGridPosition() + new Vector2Int(direction.x, direction.y);
            
            if (grid.ContainsKey(neighborPosition))
            {
                neighbor = grid[neighborPosition];

                if (!dequeuedList.Contains(neighbor) && !queue.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    neighbor.exploredFrom = searchCenter;
                }
            }
        }
    }

    private void ColorStartAndEnd() // Todo: change to SetStartAndEndPoint
    {
        startWaypoint.SetTopColor(Color.blue);
        endWaypoint.SetTopColor(Color.red);
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
    }
}
