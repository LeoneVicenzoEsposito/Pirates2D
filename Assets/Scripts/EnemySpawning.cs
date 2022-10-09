using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    private float spawnRate;

    public List<GameObject> enemies;
    public List<int> xOfSpawnOptions;   
    public List<int> yOfSpawnOptions;
    public bool canSpawn = true;

    void Start()
    {
        spawnRate = PlayerPrefs.GetFloat("spawnRate");

        if (spawnRate == 0)
        {
            spawnRate = 5;
        }
    }

    void FixedUpdate()
    {
        if (canSpawn)
        {
            int enemySpawn = UnityEngine.Random.Range(0, enemies.Count);
            int xOfSpawn = UnityEngine.Random.Range(0, xOfSpawnOptions.Count);
            int yOfSpawn = UnityEngine.Random.Range(0, xOfSpawnOptions.Count);

            Instantiate(enemies[enemySpawn], new Vector2(xOfSpawnOptions[xOfSpawn], xOfSpawnOptions[yOfSpawn]), Quaternion.identity);

            canSpawn = false;
            StartCoroutine(SpawnEnemyCooldown());   
        }   
    }

    IEnumerator SpawnEnemyCooldown()
    {
        yield return new WaitForSeconds((10f/ spawnRate));
        canSpawn = true;
    }
}
