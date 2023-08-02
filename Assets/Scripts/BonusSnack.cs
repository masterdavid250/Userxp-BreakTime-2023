using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusSnack : MonoBehaviour
{
    public GameObject[] snacks;
    public Sprite[] snackTextSprites;
    public GameObject bonusBoxText; 
    private SpriteRenderer textSpriteRenderer;
    public Transform snackPosition;
    private int snackNumber;
    private bool bonusSpawned = false;
    public string snackName;

    private void Awake()
    {
        snackNumber = Random.Range(0, snacks.Length);
        textSpriteRenderer = bonusBoxText.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (snackNumber == 0 && !bonusSpawned)
        {
            Instantiate(snacks[0], snackPosition.position, snackPosition.rotation);
            snackName = "Sakuchoo";
            textSpriteRenderer.sprite = snackTextSprites[0];
            bonusSpawned = true;
        }
        if (snackNumber == 1 && !bonusSpawned)
        {
            Instantiate(snacks[1], snackPosition.position, snackPosition.rotation);
            snackName = "Sakuratcha";
            textSpriteRenderer.sprite = snackTextSprites[1];
            bonusSpawned = true;
        }
        if (snackNumber == 2 && !bonusSpawned)
        {
            Instantiate(snacks[2], snackPosition.position, snackPosition.rotation);
            snackName = "SakuSticks";
            textSpriteRenderer.sprite = snackTextSprites[2];
            bonusSpawned = true;
        }
        if (snackNumber == 3 && !bonusSpawned)
        {
            Instantiate(snacks[3], snackPosition.position, snackPosition.rotation);
            snackName = "SakuSugar";
            textSpriteRenderer.sprite = snackTextSprites[3];
            bonusSpawned = true;
        }
        if (snackNumber == 4 && !bonusSpawned)
        {
            Instantiate(snacks[4], snackPosition.position, snackPosition.rotation);
            snackName = "Sakuron";
            textSpriteRenderer.sprite = snackTextSprites[4];
            bonusSpawned = true;
        }
    }
}
