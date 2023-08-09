using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsUI : MonoBehaviour
{
    [SerializeField] GameObject settings;

    public void ButtonSettings()
    {
        gameObject.SetActive(false);
        settings.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Button Click");
    }
}
