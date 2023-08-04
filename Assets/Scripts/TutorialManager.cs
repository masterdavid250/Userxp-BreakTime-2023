using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public Ball ball;
    public GameObject[] tutorialSnackstack;
    public GameObject bonusSnackObj;
    public GameObject powerupsObj;
    [SerializeField] private int popUpIndex;
    private GameManager gameManager;
    private Powerups powerupsScript;
    private bool isTutorialDone;
    private bool hasFinalPartStarted;
    private float waitTime = 5f;
    private float currentWaitTime;

    void Start()
    {
        UpdatePopUp();
        gameManager = GameManager.instance;
        gameManager.isInTutorial = true;
        currentWaitTime = waitTime;
        powerupsScript = powerupsObj.GetComponent<Powerups>();
        gameManager.AddLife();
    }

    // Basically delay until when to keep popup
    private IEnumerator CO_KeepPopup(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1;

        if (popUpIndex != 3 && popUpIndex != 9 && popUpIndex != 10)
        popUps[popUpIndex].GetComponent<CanvasGroup>().alpha = 0;
        Debug.Log($"A: {popUpIndex}");
    }

    // Adds delay when swtiching to next popup
    private IEnumerator CO_AddDelayToNext(float delay)
    {
        Debug.Log($"timescalse: {Time.timeScale}");
        yield return new WaitForSecondsRealtime(delay);
    }

    // Switching to the next popup
    private IEnumerator CO_GoToNextPopup(float keepDelay, float delayToNext)
    {
        yield return StartCoroutine(CO_KeepPopup(keepDelay));
        yield return StartCoroutine(CO_AddDelayToNext(delayToNext));
        isTutorialDone = false;
        popUpIndex++;
        UpdatePopUp();
    }

    // Delays next popup for tutorials where players need to test mechanics first
    private IEnumerator CO_DelayNextPopup(float delay)
    {
        yield return StartCoroutine(CO_AddDelayToNext(delay));
        isTutorialDone = false;
        gameManager.isTutorialPowerupDone = false;
        popUpIndex++;
        UpdatePopUp();
    }

    void UpdatePopUp()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {

                popUps[i].SetActive(true);
            }

            else
            {
                popUps[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Teaching movement
        if (popUpIndex == 0)
        {
            if (!isTutorialDone)
            {
                if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) ||
                    (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)))
                {
                    isTutorialDone = true;
                    StartCoroutine(CO_GoToNextPopup(3f, 2f));
                }
            }
        }

        // Launching ball
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(CO_GoToNextPopup(1f, 5f));
            }
        }

        // Showing different-sized snacks
        else if (popUpIndex == 2)
        {
            tutorialSnackstack[0].SetActive(true);
            Time.timeScale = 0;

            if (!isTutorialDone)
            {
                StartCoroutine(CO_KeepPopup(5f));
                
                if (GameObject.FindGameObjectsWithTag("Snacks").Length == 0)
                {
                    isTutorialDone = true;
                    tutorialSnackstack[0].SetActive(false);
                    StartCoroutine(CO_DelayNextPopup(2f));
                }
            }
        }

        // Lives explanation
        else if (popUpIndex == 3)
        {
            ball.ResetBall();

            if (currentWaitTime <= 0)
            {
                currentWaitTime = waitTime;
                popUpIndex++;
                UpdatePopUp();
            }

            else
            {
                currentWaitTime -= Time.deltaTime;
                Debug.Log(currentWaitTime);
            }
        }

        // Bonus snack explanation
        else if (popUpIndex == 4)
        {
            bonusSnackObj.GetComponent<BonusSnack>().enabled = true;

            if (currentWaitTime <= 0)
            {
                currentWaitTime = waitTime;
                popUpIndex++;
                UpdatePopUp();
            }

            else
            {
                currentWaitTime -= Time.deltaTime;
                Debug.Log(currentWaitTime);
            }
        }

        // Powerups explanation
        else if (popUpIndex == 5)
        {
            if (currentWaitTime <= 0)
            {
                currentWaitTime = waitTime;
                popUpIndex++;
                UpdatePopUp();
            }

            else
            {
                currentWaitTime -= Time.deltaTime;
                Debug.Log(currentWaitTime);
            }
        }

        // Using big paddles
        else if (popUpIndex == 6)
        {
            powerupsObj.SetActive(true);

            if (!isTutorialDone)
            {
                StartCoroutine(CO_KeepPopup(2f));

                if (gameManager.isTutorialPowerupDone && gameManager.currentTutorialPowerup == 1)
                {
                    isTutorialDone = true;
                    StartCoroutine(CO_DelayNextPopup(2f));
                }
            }
        }

        // Using coin swap paddles
        else if (popUpIndex == 7)
        {
            tutorialSnackstack[1].SetActive(true);

            if (!isTutorialDone)
            {
                StartCoroutine(CO_KeepPopup(2f));

                if (gameManager.isTutorialPowerupDone && GameObject.FindGameObjectsWithTag("Snacks").Length <= 1  && gameManager.currentTutorialPowerup == 2)
                {
                    tutorialSnackstack[1].SetActive(false);
                    isTutorialDone = true;
                    StartCoroutine(CO_DelayNextPopup(2f));
                }
            }
        }

        // Using sticky paddle
        else if (popUpIndex == 8)
        {
            Time.timeScale = 0;

            if (!isTutorialDone)
            {
                StartCoroutine(CO_KeepPopup(3f));

                if (gameManager.isTutorialPowerupDone && gameManager.currentTutorialPowerup == 3)
                {
                    isTutorialDone = true;
                    StartCoroutine(CO_DelayNextPopup(2f));
                }
            }
        }

        // start trial round
        else if (popUpIndex == 9)
        {
            tutorialSnackstack[2].SetActive(true);

            if (currentWaitTime <= 0)
            {
                popUps[popUpIndex].GetComponent<CanvasGroup>().alpha = 0;

                if (!isTutorialDone)
                {
                    if (GameObject.FindGameObjectsWithTag("Snacks").Length <= 1)
                    {
                        isTutorialDone = true;
                        currentWaitTime = waitTime * 1.5f;
                        tutorialSnackstack[2].SetActive(false);
                        StartCoroutine(CO_DelayNextPopup(1f));
                    }
                }
            }

            else
            {
                currentWaitTime -= Time.deltaTime;
                Debug.Log(currentWaitTime);
                ball.ResetBall();
            }
        }

        // after trial round
        else if (popUpIndex == 10)
        {
            ball.ResetBall();

            if (currentWaitTime <= 0)
            {
                currentWaitTime = waitTime;
                SceneManager.LoadScene("0_TitleScreen");
            }

            else
            {
                currentWaitTime -= Time.deltaTime;
                Debug.Log(currentWaitTime);
            }
        }
    }
}
