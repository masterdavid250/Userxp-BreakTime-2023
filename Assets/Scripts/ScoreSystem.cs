using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;

        gameManager.Score = 0; 
    }

    private void Update()
    {
        scoreText.text = gameManager.Score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
