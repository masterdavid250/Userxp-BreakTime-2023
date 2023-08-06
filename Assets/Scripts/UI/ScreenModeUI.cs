using UnityEngine;

public class ScreenModeUI : MonoBehaviour
{
    public void FullScreenButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        Screen.fullScreen = true;
    }

    public void WindowedButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        Screen.fullScreen = false;
    }
}
