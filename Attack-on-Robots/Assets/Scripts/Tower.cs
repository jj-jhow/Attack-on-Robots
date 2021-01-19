using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;
    bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SearchAndDestroy();
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
