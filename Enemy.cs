using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 10;
    public float attackRate = 1f;  // Time between attacks in seconds
    public int health = 30;
    public float attackRange = 0.5f; // How close enemy must be to attack

    private Transform player;
    private float attackTimer;
    private bool playerInRange = false;

    public void Init(Transform playerTransform)
    {
        player = playerTransform;
    }

    void Update()
    {
        if (player == null) return;

        // Move towards player
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        // Attack timer
        attackTimer += Time.deltaTime;
        if (playerInRange && attackTimer >= attackRate)
        {
            AttackPlayer();
            attackTimer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void AttackPlayer()
    {
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy attacked player for " + damage + " damage");
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }
}
