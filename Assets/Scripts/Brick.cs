using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private int health;
    [SerializeField] private int points;
    
    private BonusSnack bonusSnack;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        bonusSnack = FindObjectOfType<BonusSnack>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameManager.Score += points;

            if (name == bonusSnack.snackName)
            gameManager.AddLife();

            // Might change this so that the snack falls before being destroyed
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
            health--;
    }
}