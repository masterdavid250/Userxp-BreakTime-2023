using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject volume;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject screenMode;
    [SerializeField] private GameObject credits;

    public void VolumeButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        gameObject.SetActive(false);
        volume.SetActive(true);
    }

    public void ControlsButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        gameObject.SetActive(false);
        controls.SetActive(true);
    }

    public void ScreenModeButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        gameObject.SetActive(false);
        screenMode.SetActive(true);
    }

    public void CreditsButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        gameObject.SetActive(false);
        credits.SetActive(true);
    }

    public void ExitButton()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        Application.Quit();
    }
}
