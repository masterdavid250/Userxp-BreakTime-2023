using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI[] namesText;
    [SerializeField] private TextMeshProUGUI[] scoresText;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().Stop("Game BGM");
        FindObjectOfType<AudioManager>().Play("End BGM");
    }

    private void Start()
    {
        scoreText.text = GameManager.instance.Score.ToString();

        var scores = GameManager.instance.GetHighScores().ToArray();
        int length = Mathf.Min(scores.Length, 3);

        for (int i = 0; i < length; i++)
        {
            namesText[i].text = scores[i]._name;
            scoresText[i].text = scores[i]._score.ToString();
        }
    }

    public void RetryButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        Application.Quit();
    }
}
