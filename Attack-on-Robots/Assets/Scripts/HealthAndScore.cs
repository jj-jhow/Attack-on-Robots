using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndScore : MonoBehaviour
{
    private int score = 0;

    [SerializeField] int health = 20;
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;
    void Start()
    {
        healthText.text = "Health\n" + health.ToString();
        scoreText.text = "Score\n" + score.ToString();
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
        healthText.text = "Health\n" + health.ToString();

        if (health <= 0)
        {
            print("Game over!!!");
        }
    }

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = "Score\n" + score.ToString();
    }
}
