using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosionVFX;

    private bool died = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (died) return;

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            died = true;

            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            
            if (CameraShake.Instance != null)
                StartCoroutine(CameraShake.Instance.Shake(0.4f, 0.9f));

            if (FindObjectOfType<CameraController>() != null)
                FindObjectOfType<CameraController>().StopFollowing();

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            var controller = GetComponent<PlayerController2D>();
            if (controller != null)
                controller.enabled = false;

            Invoke(nameof(DoGameOver), 0.4f);
        }
    }

    void DoGameOver()
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
}
