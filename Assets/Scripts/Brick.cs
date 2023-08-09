using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Ball ball; 
    [SerializeField] private string snackName;
    [SerializeField] private int health;
    [SerializeField] private int points;
    [SerializeField] private Sprite[] snackSprites;
    public int spriteCount;
    
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
            if (snackName == bonusSnack.snackName)
            {
                gameManager.AddLife();
                bonusSnack.ReplaceAndRandomizeBonus();
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            health -= collision.gameObject.GetComponent<Ball>().ballDamage;
            if (health > 0 && snackSprites.Length != 0)
            {
                spriteCount++;
                this.GetComponent<SpriteRenderer>().sprite = snackSprites[spriteCount];
            }
            else if (health <= 0 && snackSprites.Length != 0)
                this.GetComponent<SpriteRenderer>().sprite = snackSprites[snackSprites.Length - 1];
        }
    }
}
