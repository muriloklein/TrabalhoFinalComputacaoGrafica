using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float stopDistance = 1.5f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
            Debug.LogError("[EnemyMovement] Player não encontrado! Adicione a tag 'Player' no objeto do player.");
    }

    void Update()
    {
        if (player == null) return;

        FollowPlayer();
    }

    void FollowPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            float spriteOffset = -90f;

            transform.rotation = Quaternion.Euler(0, 0, angle + spriteOffset);
        }
    }
}
