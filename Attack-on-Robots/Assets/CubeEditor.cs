using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    string labelText;
    int gridSize;
    TextMesh textMesh;
    Waypoint waypoint;
    Vector2 gridPosition;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        textMesh = GetComponentInChildren<TextMesh>();
        gridSize = waypoint.GetGridSize();

    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        gridPosition = waypoint.GetGridPosition();

        labelText = gridPosition.x / gridSize + "," + gridPosition.y / gridSize;
        textMesh.text = labelText;

        gameObject.name = "Cube (" + labelText + ")";
    }

    private void SnapToGrid()
    {
        gridPosition = waypoint.GetGridPosition();
        
        transform.position = new Vector3(
            gridPosition.x,
            0,
            gridPosition.y);
    }
}
