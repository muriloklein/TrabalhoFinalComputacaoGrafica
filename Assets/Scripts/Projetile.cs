using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 3f;
    public float speed = 10f;
    public GameObject explosionPrefab;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Destruir inimigo
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.AddEnemyDestroyed();
            SpawnExplosion();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // Destruir asteroide
        if (other.CompareTag("Asteroid"))
        {
            SpawnExplosion();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void SpawnExplosion()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
