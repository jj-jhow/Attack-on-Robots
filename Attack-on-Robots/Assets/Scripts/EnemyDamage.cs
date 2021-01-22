using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] ParticleSystem SelfDestructParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints < 1)
        {
            ProcessDeath(isDeath: true);
        }
    }

    public void ProcessDeath(bool isDeath)
    {
        ParticleSystem vfx;
        if (isDeath)
        {
            vfx = Instantiate(deathParticlePrefab, transform.Find("Body").position, Quaternion.identity);
        }
        else
        {
            vfx = Instantiate(SelfDestructParticlePrefab, transform.Find("Body").position, Quaternion.identity);
        }
        
        vfx.transform.parent = this.transform.parent.parent.Find("Vfx");
        vfx.Play();

        Destroy(gameObject);
        Destroy(vfx.gameObject, vfx.main.duration);
    }

    private void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }
}
