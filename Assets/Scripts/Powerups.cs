using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public GameObject               paddleMain;
    public GameObject[]             paddleSides;
    public GameManager              gameManager;
    public Ball                     ball; 
    [SerializeField] private float  scaleXMultiplier = 2f;
    private bool                    isBiggerPaddlesActivated = false;
    private bool                    isCurrencyChangeActivated = false;

    public void BiggerPaddlePowerup()
    {
        if (gameManager.Lives > 0 && !isBiggerPaddlesActivated)
        {
            gameManager.Lives--; 
            isBiggerPaddlesActivated = true;
            Vector3 currentScale1 = paddleMain.transform.localScale;
            currentScale1.x *= scaleXMultiplier;
            paddleMain.transform.transform.localScale = currentScale1;
            for (int i = 0; i < paddleSides.Length; i++)
            {
                Vector3 currentScale2 = paddleSides[i].transform.localScale;
                currentScale2.y *= scaleXMultiplier;
                paddleSides[i].transform.transform.localScale = currentScale2;
            }
            Invoke(nameof(ReturnPaddlesToNormal), 10);
        }
    }

    public void CurrencyChange()
    {
        if (gameManager.Lives > 0 && !isCurrencyChangeActivated)
        {
            gameManager.Lives--;
            isCurrencyChangeActivated = true;
            ball.ballDamage++;
            //CHANGE THE DURATION
            Invoke(nameof(ReturnPaddlesToNormal), 10);
        }
    }

    public void StickyPaddle()
    {
        //Dunno the StickyPaddle
    }

    private void ReturnPaddlesToNormal()
    {
        Vector3 currentScale1 = paddleMain.transform.localScale;
        currentScale1.x /= scaleXMultiplier;
        paddleMain.transform.transform.localScale = currentScale1;
        for (int i = 0; i < paddleSides.Length; i++)
        {
            Vector3 currentScale2 = paddleSides[i].transform.localScale;
            currentScale2.y /= scaleXMultiplier;
            paddleSides[i].transform.transform.localScale = currentScale2;
        }
        isBiggerPaddlesActivated = false;
    }

    private void ReturnCurrencyToNormal()
    {
        ball.ballDamage--;
        isCurrencyChangeActivated = false;
    }
}
