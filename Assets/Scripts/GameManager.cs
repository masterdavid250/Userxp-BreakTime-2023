using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Ball ball { get; private set; }
    public PaddleController paddle { get; private set; }
    public int Lives { get; set; }
    public int Score { get; set; }
    public string Name { get; set; }

    public List<HighScore> highScores = new List<HighScore>();

    public bool isAskingForName;

    [Header("Tutorial Variables")]
    public bool isInTutorial;
    public bool isTutorialPowerupDone;
    public int currentTutorialPowerup;

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
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
        Lives--;
    }

    public void AddLife()
    {
        Lives++;
    }

    public void SetLifeTo50()
    {
        Lives = 50;
    }

    public IEnumerable<HighScore> GetHighScores()
    {
        return highScores.OrderByDescending(x => x._score);
    }

    public void AddScore(HighScore score)
    {
        highScores.Add(score);
    }
}
