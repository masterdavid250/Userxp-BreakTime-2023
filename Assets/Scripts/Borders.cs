using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Borders : MonoBehaviour
{
    [SerializeField] GameUI gameUI;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            FindObjectOfType<AudioManager>().Play("Coin (dropped)");
            if (SceneManager.GetActiveScene().name == "1_MainGame")
            {
                gameUI.AskForName();
            }

            gameManager.Miss();
        }
    }
}
