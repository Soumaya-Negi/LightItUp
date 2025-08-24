using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnDistance = 10f;    // Min distance from player
    public float maxSpawnDistance = 20f; // Max distance from player
    public float spawnInterval = 3f;

    public Vector2 mapMinBounds;  // Set in Inspector
    public Vector2 mapMaxBounds;  // Set in Inspector

    private float timer;

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || player == null) return;

        // Pick a random direction around the player
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float spawnDist = Random.Range(spawnDistance, maxSpawnDistance);
        Vector2 spawnPos = (Vector2)player.position + randomDir * spawnDist;

        // Clamp inside map bounds
        spawnPos.x = Mathf.Clamp(spawnPos.x, mapMinBounds.x, mapMaxBounds.x);
        spawnPos.y = Mathf.Clamp(spawnPos.y, mapMinBounds.y, mapMaxBounds.y);

        // Spawn enemy
        GameObject enemyObj = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // Pass player reference to enemy
        Enemy enemyScript = enemyObj.GetComponent<Enemy>();
        if (enemyScript != null)
            enemyScript.Init(player);
    }
}
