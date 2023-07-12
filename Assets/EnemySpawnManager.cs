using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public EnemyMovement enemyPrefab;   // Reference to the enemy prefab
    public float spawnRadius = 2f;
    public float spawnInterval = 2f; // Time interval between enemy spawns
    public Transform target;
    private float timer = 0f;        // Timer to track spawn interval

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if enough time has passed to spawn a new enemy
        if (timer >= spawnInterval)
        {
            SpawnEnemy();    // Spawn the enemy
            timer = 0f;      // Reset the timer
        }
    }

    private void SpawnEnemy()
    {
        // Calculate a random position within the spawner's bounds
        var insideUnitSphere = Random.insideUnitSphere;
        insideUnitSphere.z = 0;
        Vector3 randomPosition = transform.position + insideUnitSphere * spawnRadius;

        // Instantiate the enemy at the random position
        var newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        newEnemy.targetTransform = target;
    }
}
