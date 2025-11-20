using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1.5f;
    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(enemyBulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}
