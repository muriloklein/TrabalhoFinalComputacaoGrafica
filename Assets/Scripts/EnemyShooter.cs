using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform shootPoint;

    public float baseFireRate = 1.3f;
    public float fireRateVariation = 0.5f;

    public float aimJitter = 7f;
    public float burstChance = 0.25f;
    public int burstSize = 3;
    public float burstInterval = 0.12f;

    private float fireTimer = 0f;
    private float nextFireTime;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
            Debug.LogError("Player não encontrado!");

        ScheduleNextShot();
    }

    void Update()
    {
        if (player == null) return;

        fireTimer += Time.deltaTime;

        if (fireTimer >= nextFireTime)
        {
            fireTimer = 0f;

            if (Random.value < burstChance)
            {
                StartCoroutine(FireBurst());
            }
            else
            {
                Shoot();
            }

            ScheduleNextShot();
        }
    }

    void ScheduleNextShot()
    {
        nextFireTime = baseFireRate + Random.Range(-fireRateVariation, fireRateVariation);
        nextFireTime = Mathf.Clamp(nextFireTime, 0.3f, 2.2f);
    }

    System.Collections.IEnumerator FireBurst()
    {
        for (int i = 0; i < burstSize; i++)
        {
            Shoot();
            yield return new WaitForSeconds(burstInterval);
        }
    }

    void Shoot()
    {
        if (player == null) return;

        Vector2 dir = (player.position - shootPoint.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float jitter = Random.Range(-aimJitter, aimJitter);

        Quaternion rot = Quaternion.Euler(0, 0, angle + jitter);

        Instantiate(enemyBulletPrefab, shootPoint.position, rot);
    }
}
