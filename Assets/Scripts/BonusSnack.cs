using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusSnack : MonoBehaviour
{
    public GameObject[] snacks;
    public TextMeshProUGUI bonusSnackText;
    public Transform snackPosition;
    private int snackNumber;
    private bool bonusSpawned = false;

    private void Awake()
    {
        snackNumber = Random.Range(0, snacks.Length);
    }

    private void Update()
    {
        if (snackNumber == 0 && !bonusSpawned)
        {
            Instantiate(snacks[0], snackPosition.position, snackPosition.rotation);
            bonusSnackText.text = "Sakuchoo";
            bonusSpawned = true;
        }
        if (snackNumber == 1 && !bonusSpawned)
        {
            Instantiate(snacks[1], snackPosition.position, snackPosition.rotation);
            bonusSnackText.text = "Sakuratcha";
            bonusSpawned = true;
        }
        if (snackNumber == 2 && !bonusSpawned)
        {
            Instantiate(snacks[2], snackPosition.position, snackPosition.rotation);
            bonusSnackText.text = "SakuSticks";
            bonusSpawned = true;
        }
        if (snackNumber == 3 && !bonusSpawned)
        {
            Instantiate(snacks[3], snackPosition.position, snackPosition.rotation);
            bonusSnackText.text = "SakuSugar";
            bonusSpawned = true;
        }
        if (snackNumber == 4 && !bonusSpawned)
        {
            Instantiate(snacks[4], snackPosition.position, snackPosition.rotation);
            bonusSnackText.text = "Sakuron";
            bonusSpawned = true;
        }
    }
}
