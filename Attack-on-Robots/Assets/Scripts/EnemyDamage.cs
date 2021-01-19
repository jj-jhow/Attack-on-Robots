using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;

    private void OnParticleCollision(GameObject other)
    {
        hitPoints -= 1;

        if (hitPoints < 1)
        {
            Destroy(gameObject);
        }
    }
}
