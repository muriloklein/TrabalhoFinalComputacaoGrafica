using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    private float timer;

    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 spawnPos = new Vector3(spawnAreaMin.x, y, 0);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
