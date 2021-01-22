using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints < 1)
        {
            ProcessDeath();
        }
    }

    private void ProcessDeath()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.Find("Body").position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }
}
