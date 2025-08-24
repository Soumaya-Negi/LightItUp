using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamage : MonoBehaviour
{
    public int damageOnHit = 10;         // Damage when first touching the player
    public float damageInterval = 1f;    // Time between hits if player stays in range

    private float damageTimer = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Damage player immediately when entering range
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.TakeDamage(damageOnHit);
            damageTimer = 0f;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Keep damaging over time while player stays in range
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                playerHealth.TakeDamage(damageOnHit);
                damageTimer = 0f;
            }
        }
    }
}
