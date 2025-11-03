using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // garante sem gravidade
    }

    void Update()
    {
        // Leitura de teclas (WSAD ou setas)
        float moveY = Input.GetAxisRaw("Vertical");   // W/S ou ↑/↓
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D ou ←/→

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Movimento linear
        rb.linearVelocity = moveInput * moveSpeed;

        // Opcional: girar a nave na direção do movimento
        if (moveInput.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}