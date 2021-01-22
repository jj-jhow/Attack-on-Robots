using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;
    public Waypoint baseWaypoint;

    Transform targetEnemy;

    void Update()
    {
        SetTarget();
        SearchAndDestroy();
    }

    private void SetTarget()
    {
        EnemyDamage[] enemies = FindObjectsOfType<EnemyDamage>();
        
        if (enemies.Length != 0)
        {
            Transform closestEnemy = enemies[0].transform;

            foreach (EnemyDamage enemy in enemies)
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) - Vector3.Distance(closestEnemy.position, transform.position) < Mathf.Epsilon)
	            {
                    closestEnemy = enemy.transform;
	            }

            }

            targetEnemy = closestEnemy.Find("Body");
        }
    }

    private void SearchAndDestroy()
    {
        if (targetEnemy)
        {
            float compareDistance = Mathf.Abs(Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position)) - attackRange;

            if (compareDistance <= Mathf.Epsilon)
            {
                objectToPan.LookAt(targetEnemy);
                Shoot(true);
            }
            else
            {
                Shoot(false);
            }
        }
        else
        {
            Shoot(false);
        }

        
    }

    private void Shoot(bool isActive)
    {
        var EmissionModule = projectileParticle.emission;
        EmissionModule.enabled = isActive;
    }
}
