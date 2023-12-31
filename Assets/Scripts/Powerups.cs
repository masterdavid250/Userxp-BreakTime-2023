using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerups : MonoBehaviour
{
    public GameManager              gameManager;
    public Ball                     ball; 
    public GameObject               paddleMain;
    public GameObject[]             paddleSides;
    public Image[]                  powerupLights;  
    public bool                    isBiggerPaddlesActivated = false;
    public bool                    isCurrencyChangeActivated = false;
    public bool                     isStickyPaddlesActivated = false;
    [SerializeField] private Sprite[] paddleSprites;
    [SerializeField] private Sprite[] lightSprites;
    [SerializeField] private float  scaleXMultiplier = 2f;
    private SpriteRenderer          paddleMainSpriteRenderer;

    void Start()
    {
        gameManager = GameManager.instance;
        paddleMainSpriteRenderer = paddleMain.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (gameManager.Lives > 1)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Z))
            {
                FindObjectOfType<AudioManager>().Play("Powerup");
                BiggerPaddlePowerup();
            }

            else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<AudioManager>().Play("Powerup");
                CurrencyChange();
            }

            else if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.C))
            {
                FindObjectOfType<AudioManager>().Play("Powerup");
                StickyPaddle();
            }
        }
    }

    public void BiggerPaddlePowerup()
    {
        if (!isBiggerPaddlesActivated)
        {
            gameManager.Lives -= 2; 
            isBiggerPaddlesActivated = true;
            powerupLights[0].GetComponent<Image>().sprite = lightSprites[1];

            Vector3 currentScale1 = paddleMain.transform.localScale;
            currentScale1.x *= scaleXMultiplier;
            paddleMain.transform.transform.localScale = currentScale1;
            for (int i = 0; i < paddleSides.Length; i++)
            {
                Vector3 currentScale2 = paddleSides[i].transform.localScale;
                currentScale2.x *= scaleXMultiplier;
                paddleSides[i].transform.transform.localScale = currentScale2;
            }
            Invoke(nameof(ReturnPaddlesToNormal), 10);
        }
    }

    public void CurrencyChange()
    {
        if (!isCurrencyChangeActivated)
        {
            gameManager.Lives -= 2;
            isCurrencyChangeActivated = true;
            powerupLights[1].GetComponent<Image>().sprite = lightSprites[1];

            ball.ballDamage++;
            ball.spriteRenderer.sprite = ball.ballSprites[1];
            ball.UpdateColliderSize();
            //CHANGE THE DURATION
            Invoke(nameof(ReturnCurrencyToNormal), 10);
        }
    }

    public void StickyPaddle()
    {
        if (!isStickyPaddlesActivated)
        {
            // Other part of code for this is in the ball script
            gameManager.Lives -=2;
            isStickyPaddlesActivated = true;
            powerupLights[2].GetComponent<Image>().sprite = lightSprites[1];

            paddleMainSpriteRenderer.sprite = paddleSprites[1];
            Invoke(nameof(ReturnStickyPaddleToNormal), 10);
        }
    }

    private void ReturnPaddlesToNormal()
    {
        Vector3 currentScale1 = paddleMain.transform.localScale;
        currentScale1.x /= scaleXMultiplier;
        paddleMain.transform.transform.localScale = currentScale1;
        for (int i = 0; i < paddleSides.Length; i++)
        {
            Vector3 currentScale2 = paddleSides[i].transform.localScale;
            currentScale2.x /= scaleXMultiplier;
            paddleSides[i].transform.transform.localScale = currentScale2;
        }
        isBiggerPaddlesActivated = false;
        powerupLights[0].GetComponent<Image>().sprite = lightSprites[0];
        
        // // for tutorial
        // gameManager.isTutorialPowerupDone = true;
        // gameManager.currentTutorialPowerup = 1;
    }

    private void ReturnCurrencyToNormal() 
    {
        ball.ballDamage--;
        isCurrencyChangeActivated = false;
        ball.spriteRenderer.sprite = ball.ballSprites[0];
        ball.UpdateColliderSize();
        powerupLights[1].GetComponent<Image>().sprite = lightSprites[0];
        
        // // for tutorial
        // gameManager.isTutorialPowerupDone = true;
        // gameManager.currentTutorialPowerup = 2;
    }

    private void ReturnStickyPaddleToNormal() 
    {
        paddleMainSpriteRenderer.sprite = paddleSprites[0];
        isStickyPaddlesActivated = false;
        powerupLights[2].GetComponent<Image>().sprite = lightSprites[0];

        // // for tutorial
        // gameManager.isTutorialPowerupDone = true;
        // gameManager.currentTutorialPowerup = 3;
    }
}
