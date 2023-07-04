using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int numberToHit;
    public int scoreWhenDestroyed; 

    private void Update()
    {
        if (numberToHit <= 0)
        {
            ScoreSystem.score += scoreWhenDestroyed;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
            numberToHit--; 
    }
}
