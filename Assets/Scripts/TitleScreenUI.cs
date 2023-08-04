using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    public void ButtonNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonTutorial()
    {
        SceneManager.LoadScene("2_Tutorial");
    }

    public void ButtonSettings()
    {

    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
