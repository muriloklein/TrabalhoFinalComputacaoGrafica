using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosionVFX;
    private bool exploded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (exploded) return;
        if (!collision.gameObject.CompareTag("Asteroid")) return;

        exploded = true;

        StartCoroutine(CameraShake.Instance.Shake(0.4f, 0.90f));

        Instantiate(explosionVFX, transform.position, Quaternion.identity);

        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<Rigidbody2D>());

        FindObjectOfType<CameraController>().StopFollowing();

        Invoke(nameof(CallGameOver), 0.6f);
    }

    private void CallGameOver()
    {
        GameManager.Instance.GameOver();
    }
}
