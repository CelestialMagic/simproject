using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Building
{
    [SerializeField]
    GeneratorType generator;
    [SerializeField]
    int currentSpawned = 0;
    [SerializeField]
    int maxSpawned = 100;
    [SerializeField]
    float timeSinceLastSpawn = 0;

    void Update()
    {
        if (timeSinceLastSpawn > generator.rateOfSpawn && currentSpawned < maxSpawned)
        {
            GenerateResources();
        }
        timeSinceLastSpawn += Time.deltaTime;
    }
    public (ResourceType, int) Collect()
    {
        currentSpawned = 0;
        return (generator.resource, currentSpawned);
    }
    void GenerateResources()
    {
        Debug.Log("Spawned item");
        currentSpawned += 1;
        timeSinceLastSpawn = 0;

    }
}
