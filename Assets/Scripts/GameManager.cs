using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Ball ball { get; private set; }
    public PaddleController paddle { get; private set; }
    public int Lives {get; set; }
    private int lives;
    public int Score { get; set; }

    private int score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnLevelLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<PaddleController>();
    }

    public void Miss()
    {
        if (Lives > 0)
        {
            Lives--;
            this.ball.ResetBall();
            this.paddle.ResetPaddle();
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddLife()
    {
        Lives++;
    }
}
