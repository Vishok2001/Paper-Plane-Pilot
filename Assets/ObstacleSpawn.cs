using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public int minObstaclesPerSpawn = 1;
    public int maxObstaclesPerSpawn = 3;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 2.5f;
    public float minY = -3f;
    public float maxY = 3f;
    public float spawnX = 10f;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if (obstaclePrefab == null || obstaclePrefab.Length == 0)
        {
            Debug.LogError("Obstacle Prefab is missing or not assigned in Inspector!");
        }
        else
        {
            Debug.Log("Obstacle Prefab successfully loaded!");
            StartCoroutine(SpawnObstacle());
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (!isGameOver)
        {
            int obstaclesToSpawn = Random.Range(minObstaclesPerSpawn, maxObstaclesPerSpawn);

            for (int i = 0; i < obstaclesToSpawn; i++)
            {
                SpawnRandomObstacle(); // Call the method to spawn
            }

            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime); // Wait before next spawn
        }

        Debug.Log("Spawner stopped due to Game Over."); // This will print when stopped
    }

    // ✅ Properly placed outside of coroutine
    void SpawnRandomObstacle()
    {
        // Ensure obstaclePrefab array is not null or empty
        if (obstaclePrefab == null || obstaclePrefab.Length == 0)
        {
            Debug.LogError("Obstacle Prefab array is null or empty!");
            return;
        }

        // Log the prefab names to check
        foreach (var prefab in obstaclePrefab)
        {
            if (prefab == null)
            {
                Debug.LogError("Found null prefab in the array. Please check the assignment.");
                return;
            }
        }

        GameObject randomObstacle = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];

        // Ensure the selected prefab is not null
        if (randomObstacle == null)
        {
            Debug.LogError("Selected obstacle prefab is null or destroyed!");
            return;
        }

        Debug.Log("Instantiating obstacle: " + randomObstacle.name);

        // Spawn position with some random Y position within the given range
        float randomY = Random.Range(minY, maxY);
        float randomXOffset = Random.Range(0f, 3f); // Scatter horizontally

        Vector3 spawnPosition = new Vector3(spawnX + randomXOffset, randomY, 0);

        // Optional: Add random rotation for variety
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(-15f, 15f));

        // Instantiate the obstacle at the given position with a random rotation
        Instantiate(randomObstacle, spawnPosition, randomRotation);
    }

    // ✅ Correct place for stopping
    public void StopSpawning()
    {
        isGameOver = true; // Stop spawning when game ends
        Debug.Log("Spawning stopped. Game Over Triggered.");
    }
}