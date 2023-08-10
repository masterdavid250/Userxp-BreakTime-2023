using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI  scoreText;
    public GameObject[]     snackStack;
    public Transform        snackStackSpawnLocation;
    private GameManager     gameManager;
    private GameObject[]    allSnacks;
    public Ball ball;

    private void Start()
    {
        gameManager = GameManager.instance;
        gameManager.Score = 0; 
    }

    private void Update()
    {
        allSnacks = GameObject.FindGameObjectsWithTag("Snacks");
        if (allSnacks.Length <= 1 && SceneManager.GetActiveScene().name != "2_Tutorial")
            RespawnSnacks(); 
        scoreText.text = gameManager.Score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RespawnSnacks()
    {
        GameObject newStack = Instantiate(snackStack[Random.Range(0, snackStack.Length)], snackStackSpawnLocation.position, snackStackSpawnLocation.rotation);
        newStack.SetActive(true); 
        ball.speed *= 1.1f;
    }
}
