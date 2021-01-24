using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;

    public bool isExplored = false;
    public bool isPlaceable = true;
    public bool isExplorable = true;

    [SerializeField] Tower towerPrefab;

    TowerFactory towerFactory;

    private void Start()
    {
        towerFactory = FindObjectOfType<TowerFactory>();
    }
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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && isPlaceable)
        {
            towerFactory.AddTower(this);
        }
    }
}
