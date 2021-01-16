using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;


    void Update()
    {
        Vector3 snapPosition;
        TextMesh textMesh;

        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPosition.y = 0f;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPosition.x, snapPosition.y, snapPosition.z);
       
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
    }
}
