using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public bool isPlaceable = true;

    [SerializeField] Tower towerPrefab;
    [SerializeField] public bool isExplorable = true;

    const int gridSize = 10;

    public int GetGridSize()
    { 
        return gridSize;
    }
    public Waypoint exploredFrom { get; set; }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && isPlaceable)
        {
            PlaceTower();
        }
    }

    private void PlaceTower()
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isPlaceable = false;
    }
}
