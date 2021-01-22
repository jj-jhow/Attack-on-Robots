using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;

    private void OnTriggerEnter(Collider other)
    {
        health = health - healthDecrease;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            print("Game over!!!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
