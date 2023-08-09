using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject nameBox;
    [SerializeField] TMP_InputField nameInput;

    private void Start()
    {
        nameBox.SetActive(false);
        nameInput.onEndEdit.AddListener(SubmitName);
    }

    public void AskForName()
    {
        if (GameManager.instance.Lives <= 0 && !GameManager.instance.isInTutorial)
        {
            nameBox.SetActive(true);
            GameManager.instance.isAskingForName = true;
        }
    }

    private void SubmitName(string name)
    {
        GameManager.instance.AddScore(new HighScore(name, GameManager.instance.Score));
        SceneManager.LoadScene(3);
    }
}
