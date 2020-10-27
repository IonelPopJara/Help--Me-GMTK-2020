using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static bool canSpawnEnemy;
    public GameObject EnemyPrefab;

    public float timeBtwSpawns;
    public float currentTime;

    private void Start()
    {
        currentTime = timeBtwSpawns;
        canSpawnEnemy = true;
    }

    private void Update()
    {
        if(canSpawnEnemy)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (currentTime <= 0)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);

            currentTime = timeBtwSpawns;
        }
    }
}
