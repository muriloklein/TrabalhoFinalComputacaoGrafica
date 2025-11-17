using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 3f;
    public float speed = 10f;

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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // Destruir asteroide
        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
