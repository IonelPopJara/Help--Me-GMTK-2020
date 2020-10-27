using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("UI TextMeshPro")]
    public TextMeshProUGUI UITime;
    public TextMeshProUGUI UIScore;

    [Header("Player Controller")]
    public PlayerController playerController;

    private float currentTime;

    private void Update()
    {
        if (!GameManager.levelLoaded)
        {
            return;
        }

        currentTime += Time.deltaTime;

        UITime.text = "Time: " + currentTime.ToString("0");
        UIScore.text = "Deaths: " + playerController.deathsCounter.ToString();
    }
}
