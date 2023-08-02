using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    public TMP_Text coinsText;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.Lives = 1;
    }

    void Update()
    {
        coinsText.text = Mathf.Clamp(gameManager.Lives, 0, gameManager.Lives).ToString();
    }
}
