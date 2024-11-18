using System.Collections;
using UnityEngine;

public class SpawnS : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Score;
    private float[] DropRate = { 0.3f, 0.6f, 1f};

    [SerializeField]
    private float SpawnTime = 5f, MinSpawnTime = 1f;
    private float DropChange;

    private bool isSpawn = false;

    void Update()
    {
        if (isSpawn == false)
        {
            isSpawn = true;
            StartCoroutine(SpawnSc());
        }
    }

    IEnumerator SpawnSc()
    {
        transform.position = new Vector2(Random.Range(-10.7f, 10.7f), Random.Range(-4.8f, 4.8f));

        DropChange = Random.Range(0f, 1f);

        for (int i = 0; i < Score.Length; i++)
        {
            if (DropChange <= DropRate[i])
            {
                Instantiate(Score[i], transform.position, Quaternion.identity);
                break;
            }
        }
        yield return new WaitForSeconds(SpawnTime);
        isSpawn = false;
    }

    public void DecreaseSpawnSTime()
    {
        if (SpawnTime > MinSpawnTime)
        {
            SpawnTime -= 1f;
        }
    }

}
