using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public GameObject enemyPrefab;
    public int maxEnemies = 7;
    public float spawnInterval = 1.5f;

    private float timer;

    private List<EnemySpawner> spawners = new List<EnemySpawner>();
    private List<GameObject> aliveEnemies = new List<GameObject>();

    public Transform player;

    void Awake()
    {
        Instance = this;

        spawners = FindObjectsOfType<EnemySpawner>().ToList();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            TrySpawnEnemy();
            timer = 0f;
        }
    }

    void TrySpawnEnemy()
    {
        if (aliveEnemies.Count >= maxEnemies)
            return;

        List<EnemySpawner> nearest = spawners
            .OrderBy(s => Vector2.Distance(s.transform.position, player.position))
            .Take(3)
            .ToList();

        EnemySpawner chosenSpawner = nearest[Random.Range(0, nearest.Count)];

        GameObject enemy = chosenSpawner.SpawnEnemy(enemyPrefab);
        aliveEnemies.Add(enemy);

        enemy.GetComponent<EnemyHealth>().onDeath += () =>
        {
            aliveEnemies.Remove(enemy);
            TrySpawnEnemy();
        };
    }
}
