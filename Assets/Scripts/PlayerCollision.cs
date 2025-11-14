using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosionVFX;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("nave colide");
            
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }
}
