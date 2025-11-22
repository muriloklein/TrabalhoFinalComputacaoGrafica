using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public event Action onDeath;
    public int life = 1;

    public void TakeDamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            onDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
