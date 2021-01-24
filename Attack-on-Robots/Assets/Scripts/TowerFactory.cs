using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerPrefab;
    
    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint newWaypoint)
    {
        if (towerQueue.Count < towerLimit)
        {
            Tower newTower = Instantiate(towerPrefab, newWaypoint.transform.position, Quaternion.identity);
            newTower.transform.parent = this.transform;
            towerQueue.Enqueue(newTower);

            newTower.baseWaypoint = newWaypoint;
            newWaypoint.isPlaceable = false;
        }
        else
        {
            MoveTower(newWaypoint);
        }
    }

    private void MoveTower(Waypoint newWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();
        towerQueue.Enqueue(oldTower);

        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.baseWaypoint = newWaypoint;
        newWaypoint.isPlaceable = false;

        oldTower.transform.position = newWaypoint.transform.position;
    }
}
