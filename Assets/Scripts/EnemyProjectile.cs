using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 6f;
    public float lifeTime = 4f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Se a velocidade é zero, não rotaciona
        if (rb.linearVelocity.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;

            // Ajuste dependendo do sprite
            float spriteOffset = -90f;

            transform.rotation = Quaternion.Euler(0, 0, angle + spriteOffset);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }

        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}
