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
        if (other.CompareTag("Enemy"))
        {
            SpawnExplosion();

            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
            }
            else
            {
                Destroy(other.gameObject);
            }

            GameManager.Instance.AddEnemyDestroyed();
            Destroy(gameObject);
        }

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
