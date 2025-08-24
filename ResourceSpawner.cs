using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [Header("Resource Prefabs")]
    public GameObject woodPrefab;
    public GameObject stonePrefab;

    [Header("Spawn Settings")]
    public int initialWoodCount = 20;     // How many to spawn at start
    public int initialStoneCount = 20;
    public float spawnInterval = 10f;     // Time between new spawns
    public int maxResources = 100;        // Limit to avoid too many objects

    [Header("Spawn Area")]
    public Vector2 mapMinBounds;  // Bottom-left corner of your map
    public Vector2 mapMaxBounds;  // Top-right corner of your map

    private List<GameObject> spawnedResources = new List<GameObject>();

    void Start()
    {
        // Initial spawn at game start
        SpawnMultipleResources(woodPrefab, initialWoodCount);
        SpawnMultipleResources(stonePrefab, initialStoneCount);

        // Repeat spawning periodically
        InvokeRepeating(nameof(SpawnRandomResources), spawnInterval, spawnInterval);
    }

    void SpawnMultipleResources(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnResource(prefab);
        }
    }

    void SpawnResource(GameObject prefab)
    {
        if (spawnedResources.Count >= maxResources) return; // Limit resources

        Vector2 randomPos = new Vector2(
            Random.Range(mapMinBounds.x, mapMaxBounds.x),
            Random.Range(mapMinBounds.y, mapMaxBounds.y)
        );

        GameObject resource = Instantiate(prefab, randomPos, Quaternion.identity);
        spawnedResources.Add(resource);
    }

    void SpawnRandomResources()
    {
        SpawnResource(woodPrefab);
        SpawnResource(stonePrefab);
    }
}
