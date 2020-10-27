using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyMapping;
    private bool gameStarted;

    private void Awake()
    {
        EnemyMapping.SetActive(false);
        gameStarted = false;
    }

    private void Update()
    {
        if (gameStarted)
            return;
        if(GameManager.levelLoaded)
        {
            EnemyMapping.SetActive(true);
            gameStarted = true;
        }
    }
}
