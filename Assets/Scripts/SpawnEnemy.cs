using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Enemy;

    private float[] EnemyRate = {0.2f, 0.4f, 1f};
    private float SpawnRate;

    [SerializeField]
    private GameObject Player; 

    private bool isSpawn = false;

    [SerializeField]
    private float SpawnDistance = 1f;

    [SerializeField]
    private float SpawnTime = 6f, MinSpawnTime = 1f;

    void Update()
    {
        if (isSpawn == false)
        {
            isSpawn = true;
            Vector2 spawnPosition = SpawnPosition();
            transform.position = spawnPosition;
            StartCoroutine(SpawnThing());
        }
    }

    Vector2 SpawnPosition()
    {
        Vector2 spawnPosition;
        do
        {
            spawnPosition = new Vector2(Random.Range(-10.7f, 10.7f), Random.Range(-4.8f, 4.8f));
        }
        while (Vector2.Distance(spawnPosition, Player.transform.position) < SpawnDistance); 
        return spawnPosition;
    }

    IEnumerator SpawnThing()
    {
        SpawnRate = Random.Range(0f,1f);

        for(int i = 0; i < Enemy.Length; i++)
        {
            if(SpawnRate <= EnemyRate[i])
            {
                Instantiate(Enemy[i], transform.position, Quaternion.identity);
                break;
            }
        }

        yield return new WaitForSeconds(SpawnTime);
        isSpawn = false;
    }


    public void DecreaseSpawnEnemyTime()
    {
        if (SpawnTime > MinSpawnTime)
        {
            SpawnTime -= 1f;
        }
    }
}
