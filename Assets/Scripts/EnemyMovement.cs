using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float steerStrength = 4f;
    public float stopDistance = 1.3f;

    private Transform player;
    private Vector2 velocity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
            Debug.LogError("Player não encontrado!");
    }

    void Update()
    {
        if (player == null) return;

        Vector2 toPlayer = (player.position - transform.position);
        float distance = toPlayer.magnitude;

        if (distance > stopDistance)
        {
            Vector2 desired = toPlayer.normalized * moveSpeed;
            velocity = Vector2.Lerp(velocity, desired, steerStrength * Time.deltaTime);

            transform.position += (Vector3)(velocity * Time.deltaTime);

            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
        else
        {
            velocity = Vector2.zero;
        }
    }
}