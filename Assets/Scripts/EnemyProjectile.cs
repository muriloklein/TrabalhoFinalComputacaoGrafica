using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject explosionVFX;
    public AudioClip hitSound;
    public float speed = 6f;
    public float lifeTime = 4f;

    private Rigidbody2D rb;
    private bool exploded = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (rb != null)
            rb.linearVelocity = rb.linearVelocity * speed;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (rb == null) return;

        if (rb.linearVelocity.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            float spriteOffset = -90f;
            transform.rotation = Quaternion.Euler(0, 0, angle + spriteOffset);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !exploded)
        {
            exploded = true;

            AudioSource.PlayClipAtPoint(hitSound, transform.position);

            Instantiate(explosionVFX, transform.position, Quaternion.identity);

            if (CameraShake.Instance != null)
                StartCoroutine(CameraShake.Instance.Shake(0.4f, 0.9f));

            if (FindObjectOfType<CameraController>() != null)
                FindObjectOfType<CameraController>().StopFollowing();

            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<Rigidbody2D>());

            Invoke(nameof(CallGameOver), 0.6f);
        }

        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

    private void CallGameOver()
    {
        GameManager.Instance.GameOver();
    }
}
