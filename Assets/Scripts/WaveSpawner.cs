using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Wave
{
    public string waveTitle; 
    public int totalSpawnEnemies;
    public int numberOfRandomSpawnPoint;
    public float delayStart;
    public float spawnInterval;
    public int numberOfPowerUp;
}

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    public List<Wave> waves;         

    [Header("References")]
    public Transform[] spawnPoints;  
    public GameObject enemyPrefab;     
    public GameObject powerUpPrefab;  

    void Start()
    {
        if (waves.Count > 0 && spawnPoints.Length > 0)
        {
            StartCoroutine(SpawnSystemRoutine());
        }
    }

    // Coroutine ??????????????????? Wave ????????
    IEnumerator SpawnSystemRoutine()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            Debug.Log("Start Wave" + waves[i].waveTitle);

            yield return StartCoroutine(RunWave(waves[i]));

            Debug.Log("End Wave" + (i + 1));

            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator RunWave(Wave config)
    {
        List<Transform> selectedPoints = GetRandomPoints(config.numberOfRandomSpawnPoint);

        for (int i = 0; i < config.numberOfPowerUp; i++)
        {
            Transform randomPt = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(powerUpPrefab, randomPt.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(config.delayStart);

        for (int i = 0; i < config.totalSpawnEnemies; i++)
        {
            Transform spawnPt = selectedPoints[Random.Range(0, selectedPoints.Count)];

            Instantiate(enemyPrefab, spawnPt.position, Quaternion.identity);

   
            yield return new WaitForSeconds(config.spawnInterval);
        }
    }

    List<Transform> GetRandomPoints(int count)
    {
        List<Transform> pool = new List<Transform>(spawnPoints);
        List<Transform> result = new List<Transform>();

        int actualCount = Mathf.Min(count, pool.Count);

        for (int i = 0; i < actualCount; i++)
        {
            int index = Random.Range(0, pool.Count);
            result.Add(pool[index]);
            pool.RemoveAt(index); 
        }
        return result;
    }
}