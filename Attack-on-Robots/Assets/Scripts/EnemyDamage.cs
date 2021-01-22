using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int damage = 2;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] ParticleSystem SelfDestructParticlePrefab;
    [SerializeField] int enemyScoreValue = 1;


    HealthAndScore playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<HealthAndScore>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (health < 1)
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
            playerHealth.IncreaseScore(enemyScoreValue);
        }
        else
        {
            vfx = Instantiate(SelfDestructParticlePrefab, transform.Find("Body").position, Quaternion.identity);
            playerHealth.DecreaseHealth(damage);
        }
        
        vfx.transform.parent = this.transform.parent.parent.Find("Vfx");
        vfx.Play();

        Destroy(gameObject);
        Destroy(vfx.gameObject, vfx.main.duration);
    }

    private void ProcessHit()
    {
        health -= 1;
        hitParticlePrefab.Play();
    }
}
