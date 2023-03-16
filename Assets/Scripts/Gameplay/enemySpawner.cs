using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7f;
    public float timeBtwSpawns;

    public GameObject[] enemies;

    void Start()
    {
        StartCoroutine(spawnAnEnemy());
    }

    IEnumerator spawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwSpawns);
        StartCoroutine(spawnAnEnemy());
    }
}
