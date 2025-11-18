using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    private bool playerAlive = true;

    void Start()
    {
        if (player != null)
            offset = transform.position - player.position;
    }

    public void StopFollowing()
    {
        playerAlive = false;
    }

    void LateUpdate()
    {
        if (!playerAlive || player == null)
            return;

        transform.position = player.position + offset;
    }
}
