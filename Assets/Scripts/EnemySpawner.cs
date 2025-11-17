using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 5;
    public float spawnAreaWidth = 20f;
    public float spawnAreaHeight = 10f;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = new Vector2(
                Random.Range(-spawnAreaWidth, spawnAreaWidth),
                Random.Range(-spawnAreaHeight, spawnAreaHeight)
            );

            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
}
