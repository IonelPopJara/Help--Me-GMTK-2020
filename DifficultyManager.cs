using System.Collections;
using TMPro;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static bool canMove;

    [Header("Game Objects")]
    public PlayerController player;

    [Header("Time")]
    public float qteTime;
    public float minQTETime;
    public float speed;
    public float maxSpeed;

    public float walkSoundTime = 0.5f;
    private float currentWalkTime;


    private void Awake()
    {
        player.qteTime = qteTime;
    }

    private void Start()
    {
        canMove = true;
    }

    private void Update()
    {
        if(!GameManager.levelLoaded)
        {
            return;
        }
        if(canMove)
        {
            if (speed < maxSpeed)
            {
                speed += Time.deltaTime * 0.5f;
            }

            if (qteTime > minQTETime)
            {
                qteTime -= Time.deltaTime * 0.05f;
            }

            PlayerController.speed = speed;
            player.qteTime = qteTime;
        }
        if(!canMove)
        {
            //speed = 0;
        }

        /*
        if(PlayerController.speed != 0)
        {
            if (currentWalkTime > 0)
            {
                currentWalkTime -= Time.deltaTime;
            }
            else if (currentWalkTime <= 0)
            {
                int walkn = Random.Range(1, 4);
                FindObjectOfType<AudioManager>().Play("Walk" + walkn.ToString());
                currentWalkTime = walkSoundTime;
            }
        }*/
    }
}
