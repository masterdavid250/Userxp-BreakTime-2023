using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusSnack : MonoBehaviour
{
    public GameObject[] snacks;
    public Sprite[] snackTextSprites;
    public GameObject bonusBoxText;
    public GameObject spawnedBonusSnack; 
    private SpriteRenderer textSpriteRenderer;
    public Transform snackPosition;
    private int snackNumber;
    private bool bonusSpawned = false;
    public string snackName;
    private string[] nameStacks = { "Sakuchoo", "Sakuratcha", "SakuSticks", "SakuSugar", "Sakuron" };

    private void Awake()
    {
        snackNumber = Random.Range(0, snacks.Length);
        textSpriteRenderer = bonusBoxText.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        for (int i = 0; i < snacks.Length; i++)
        {
            SpawnSnack(i, nameStacks[i]);
        }
    }

    public void SpawnSnack(int snackInt, string snackTitle)
    {
        if (snackNumber == snackInt && !bonusSpawned)
        {
            spawnedBonusSnack = Instantiate(snacks[snackInt], snackPosition.position, snackPosition.rotation);
            snackName = snackTitle;
            textSpriteRenderer.sprite = snackTextSprites[snackInt];
            bonusSpawned = true;
        }
    }

    public void ReplaceAndRandomizeBonus()
    {
        Destroy(spawnedBonusSnack);
        bonusSpawned = false;
        snackNumber = Random.Range(0, snacks.Length);
    }
}
