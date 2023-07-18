using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI  scoreText;
    public GameObject[]     allSnacks;
    public GameObject       snackStack;
    public Transform        snackStackSpawnLocation;
    private GameManager     gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        gameManager.Score = 0; 
    }

    private void Update()
    {
        allSnacks = GameObject.FindGameObjectsWithTag("Snacks");
        if (allSnacks == null)
            RespawnSnacks(); 
        scoreText.text = gameManager.Score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RespawnSnacks()
    {
        GameObject newStack = Instantiate(snackStack, snackStackSpawnLocation.position, snackStackSpawnLocation.rotation);
        newStack.SetActive(true); 
    }
}
