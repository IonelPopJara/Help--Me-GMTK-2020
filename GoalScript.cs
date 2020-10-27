using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public PlayerController player;
    public DifficultyManager dif;

    public GameObject BadPanel;
    public GameObject GoodPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (player.deathsCounter != 0)
            {
                print("Final Malo");
                BadPanel.SetActive(true);
            }
            else
            {
                print("Final Bueno");
                GoodPanel.SetActive(true);
            }
        }
    }
}
