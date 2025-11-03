using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 0.2f;
    public float maxSpeed = 8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(moveX, moveY);
        Vector2 newVelocity = rb.linearVelocity + direction * acceleration;

        // Limita a velocidade máxima
        newVelocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, newVelocity, Time.deltaTime * 5f);

        // Mantém o avião dentro da tela
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8f, 8f);
        pos.y = Mathf.Clamp(pos.y, -4f, 4f);
        transform.position = pos;
    }
}
