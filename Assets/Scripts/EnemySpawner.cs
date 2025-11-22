using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float areaX = 5f;
    public float areaY = 3f;

    public GameObject SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 basePos = transform.position;

        float randomX = Random.Range(-areaX / 2f, areaX / 2f);
        float randomY = Random.Range(-areaY / 2f, areaY / 2f);

        Vector3 spawnPos = new Vector3(
            basePos.x + randomX,
            basePos.y + randomY,
            basePos.z
        );

        return Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawCube(transform.position, new Vector3(areaX, areaY, 0.1f));

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaX, areaY, 0.1f));
    }
}
