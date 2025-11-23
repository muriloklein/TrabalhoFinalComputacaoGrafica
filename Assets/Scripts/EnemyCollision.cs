using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject explosionVFX;

    private bool destroyed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyed) return;

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            destroyed = true;

            if (explosionVFX != null)
                Instantiate(explosionVFX, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destroyed) return;

        if (other.CompareTag("Asteroid"))
        {
            destroyed = true;

            if (explosionVFX != null)
                Instantiate(explosionVFX, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
