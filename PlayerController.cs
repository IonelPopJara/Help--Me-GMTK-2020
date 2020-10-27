using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float speed;
    public static bool quickTimeEventOn;

    public Animator animator;

    [Header("Score")]
    public int deathsCounter;

    [Header("QTE Timer")]
    [HideInInspector]
    public float qteTime;
    public float currentTime;
    public GameObject QTEBar;

    [Header("QTE Keys")]
    public KeyCode key0 = KeyCode.None;
    public KeyCode key1 = KeyCode.None;
    public KeyCode key2 = KeyCode.None;
    public int keyNumber = 0;

    [Header("Speed")]
    public float previousSpeed;
    private Enemy currentEnemy;

    private void Awake()
    {
        speed = 0;
    }
    private void Start()
    {
        quickTimeEventOn = false;
        previousSpeed = speed;
    }

    private void Update()
    {
        animator.SetFloat("speed", speed);

        //print(quickTimeEventOn);
        if(quickTimeEventOn)
        {
            QuickTimeEvent();
            QTEBar.SetActive(true);
        }
        if(Spawner.canSpawnEnemy)
        {
            previousSpeed = speed;
        }
        if (!quickTimeEventOn)
            QTEBar.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.CompareTag("Enemy"))
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                IncomingAttack(enemy);
            }
        }
    }

    private void IncomingAttack(Enemy enemy)
    {
        animator.SetBool("Wait", true);

        quickTimeEventOn = true;
        DifficultyManager.canMove = false;
        Spawner.canSpawnEnemy = false;
        previousSpeed = speed;
        currentEnemy = enemy;
        currentTime = qteTime;

        currentEnemy.animator.SetBool("Wait", true);

        key0 = currentEnemy.qteKeys[0];
        key1 = currentEnemy.qteKeys[1];
        key2 = currentEnemy.qteKeys[2];
    }

    private void QuickTimeEvent()
    {
        speed = 0;
        //Si se completan los qte
        if(currentEnemy != null)
        {
            if (currentEnemy.qteCounter <= 0)
            {
                //Relief animation
                StartCoroutine(SpareEnemy(1));
                return;
            }

            //Timer
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;

                if (Input.GetKeyDown(currentEnemy.qteKeys[keyNumber]))
                {
                    FindObjectOfType<AudioManager>().Play("Right");
                    StartCoroutine(FindObjectOfType<CameraShake>().Shake(.1f, .05f));

                    currentEnemy.qteCounter -= 1;
                    currentTime = qteTime;
                    if (keyNumber < 2)
                        keyNumber++;
                    return;
                }
                else if (Input.anyKeyDown)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
                        return;
                    
                    FindObjectOfType<AudioManager>().Play("Wrong");
                    StartCoroutine(FindObjectOfType<CameraShake>().Shake(.3f,.3f));

                    StartCoroutine(KillEnemy(1));
                    return;
                }
            }
            else if (currentTime <= 0)
            {
                FindObjectOfType<AudioManager>().Play("Wrong");
                StartCoroutine(FindObjectOfType<CameraShake>().Shake(.3f, .3f));
                StartCoroutine(KillEnemy(1));
            }
        }
    }

    private IEnumerator KillEnemy(float time)
    {
        //el time en death es para la animaci[on
        quickTimeEventOn = false;

        deathsCounter++;

        StartCoroutine(currentEnemy.Death(2f));
        //print("Espera");
        yield return new WaitForSeconds(time);

        //print("Enemy death");

        FindObjectOfType<AudioManager>().Play("Death");

        animator.SetTrigger("Attack");

        currentEnemy = null;
        keyNumber = 0;
        //speed = previousSpeed;

        Spawner.canSpawnEnemy = true;

        key0 = KeyCode.None;
        key1 = KeyCode.None;
        key2 = KeyCode.None;

        //Points or life
    }

    private IEnumerator SpareEnemy(float time)
    {
        //print("Espera");
        //el time en death es para la animaci[on
        quickTimeEventOn = false;

        StartCoroutine(currentEnemy.Spare(2f));

        yield return new WaitForSeconds(time);

        //print("Enemy spare");

        FindObjectOfType<AudioManager>().Play("Spare");

        currentEnemy = null;
        keyNumber = 0;
        //speed = previousSpeed;

        animator.SetBool("Wait", false);

        Spawner.canSpawnEnemy = true;

        key0 = KeyCode.None;
        key1 = KeyCode.None;
        key2 = KeyCode.None;

        //Points or life
    }
}
