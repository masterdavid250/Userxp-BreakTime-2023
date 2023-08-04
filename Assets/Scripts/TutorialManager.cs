using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public enum TutorialPhase
{
    Movement, 
    PressSpace,
    ShowDifferentSnacksText, 
    HitSnacksToSeeHitPoints,
    Lives,
    BonusSnack,
    PowerupsIntro,
    BigPaddles,
    CoinSwapText, 
    CoinSwapHit,
    StickyPaddle,
    FinalTrialText,
    FinalTrialGame,
    EndText
}

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public Ball ball;
    public GameObject[] tutorialSnackstack;
    public GameObject bonusSnackObj;
    public GameObject powerupsObj;
    private GameManager gameManager;
    private bool[] movementCheckers = new bool[4] { false, false, false, false };
    private int movementStack = 0;
    private int popupNumber = 0;
    private int snackGroupNumber = 0;
    private bool isBallIntroLaunched = false; 
    private TutorialPhase tutorialPhase = TutorialPhase.Movement; 

    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.isInTutorial = true;
        gameManager.SetLifeTo50();
        for (int i = 0; i < movementCheckers.Length; i++)
        {
            movementCheckers[i] = false;
        }
    }

    void Update()
    {
        if (gameManager.Lives <= 0)
            gameManager.SetLifeTo50();
        if (tutorialPhase == TutorialPhase.Movement && Input.GetKeyDown(KeyCode.Space))
            isBallIntroLaunched = true; 
        if (isBallIntroLaunched)
            ball.ResetBall();

        //First Tutorial Movement Tec
        if (tutorialPhase == TutorialPhase.Movement)
        {
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !movementCheckers[0])
                MovementTutorialCheck(0);
            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !movementCheckers[1])
                MovementTutorialCheck(1);
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !movementCheckers[2])
                MovementTutorialCheck(2);
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !movementCheckers[3])
                MovementTutorialCheck(3);
            if (movementStack >= 4)
                ShowAndHidePopUp();
        }
        //Second Tutorial Press Space
        else if (tutorialPhase == TutorialPhase.PressSpace)
        {
            isBallIntroLaunched = false; 
            if (Input.GetKeyDown(KeyCode.Space))
                ShowAndHidePopUp();
        }
        //Third Tutorial Showing Different Snacks
        else if (tutorialPhase == TutorialPhase.ShowDifferentSnacksText)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                JustHidePopUpDontShowNext();
        }
        //Fourth Tutorial Showing Number of Hits 
        else if (tutorialPhase == TutorialPhase.HitSnacksToSeeHitPoints)
        {
            tutorialSnackstack[snackGroupNumber].SetActive(true);
            if (GameObject.FindGameObjectsWithTag("Snacks").Length == 0)
            {
                DisableSnackEnablePopUp();
                snackGroupNumber++;
            }
        }
        //Fifth Tutorial Lives
        else if (tutorialPhase == TutorialPhase.Lives)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                ResetBallAndNextPopUp();
        }
        //Sixth Tutorial Bonus Snacks
        else if (tutorialPhase == TutorialPhase.BonusSnack)
        {
            bonusSnackObj.GetComponent<BonusSnack>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Return))
                ResetBallAndNextPopUp();
        }
        //Seventh Tutorial Powerups Introduction 
        else if (tutorialPhase == TutorialPhase.PowerupsIntro)
        { 
            if (Input.GetKeyDown(KeyCode.Return))
                ResetBallAndNextPopUp();
        }
        //Eighth Tutorial Big Paddles
        else if (tutorialPhase == TutorialPhase.BigPaddles)
        {   
            powerupsObj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q) || (Input.GetKeyDown(KeyCode.Z)))
                ResetBallAndNextPopUp();
        }
        //Ninth Tutorial Coin Swap Text
        else if (tutorialPhase == TutorialPhase.CoinSwapText)
        {
            if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.X)))
                JustHidePopUpDontShowNext();
        }
        //Tenth Tutorial Coin Swap Hitting the Snacks
        else if (tutorialPhase == TutorialPhase.CoinSwapHit)
        {
            tutorialSnackstack[snackGroupNumber].SetActive(true);
            if (GameObject.FindGameObjectsWithTag("Snacks").Length <= 1)
            {
                DisableSnackEnablePopUp();
                snackGroupNumber++; 
            }
        }
        //Eleventh Tutorial Sticky Paddle 
        else if (tutorialPhase == TutorialPhase.StickyPaddle)
        {
            if (Input.GetKeyDown(KeyCode.R) || (Input.GetKeyDown(KeyCode.C)))
                ShowAndHidePopUp();
        }
        //Twelfth Tutorial Final Trial Text
        else if (tutorialPhase == TutorialPhase.FinalTrialText)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                JustHidePopUpDontShowNext(); 
        }
        //Thirteenth Tutorial Final Trial Game
        else if (tutorialPhase == TutorialPhase.FinalTrialGame)
        {
            tutorialSnackstack[snackGroupNumber].SetActive(true);
            if (GameObject.FindGameObjectsWithTag("Snacks").Length <= 1)
                DisableSnackEnablePopUp();
        }
        //Fourteenth Tutorial Final Text 
        else if (tutorialPhase == TutorialPhase.EndText)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene("0_TitleScreen");
        }
    }

    private void MovementTutorialCheck(int entry)
    {
        movementStack++;
        movementCheckers[entry] = true;
    }

    private void ShowAndHidePopUp()
    {
        popUps[popupNumber].SetActive(false);
        popupNumber++;
        popUps[popupNumber].SetActive(true);
        tutorialPhase++;
    }

    private void ResetBallAndNextPopUp()
    {
        ball.ResetBall();
        ShowAndHidePopUp();
    }

    private void JustHidePopUpDontShowNext()
    {
        popUps[popupNumber].SetActive(false);
        popupNumber++;
        tutorialPhase++;
    }

    private void DisableSnackEnablePopUp()
    {
        tutorialSnackstack[snackGroupNumber].SetActive(false);
        popUps[popupNumber].SetActive(true);
        ball.ResetBall();
        tutorialPhase++;
    }
}
