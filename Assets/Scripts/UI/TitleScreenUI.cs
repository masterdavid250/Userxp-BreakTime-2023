using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] GameObject settings;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().StopAllAudio();
        FindObjectOfType<AudioManager>().Play("Menu BGM");
    }

    public void ButtonNewGame()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonTutorial()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        SceneManager.LoadScene("2_Tutorial");
    }

    public void ButtonSettings()
    {
        gameObject.SetActive(false);
        settings.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Button Click");
    }

    public void ButtonExit()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        Application.Quit();
    }
}
