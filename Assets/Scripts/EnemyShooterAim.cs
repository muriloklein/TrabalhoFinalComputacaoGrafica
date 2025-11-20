using UnityEngine;

public class EnemyShooterAim : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1.5f;
    private float fireTimer;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
            Debug.LogError("[EnemyShooterAim] Nenhum player encontrado! Adicione a tag Player no objeto do jogador.");
    }

    void Update()
    {
        if (player == null) return;

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            ShootAtPlayer();
            fireTimer = 0f;
        }
    }

     void ShootAtPlayer()
     {
          GameObject bullet = Instantiate(enemyBulletPrefab, shootPoint.position, Quaternion.identity);

          Vector2 direction = (player.position - shootPoint.position).normalized;

          Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
          rb.linearVelocity = direction * 6f;
     }
}
