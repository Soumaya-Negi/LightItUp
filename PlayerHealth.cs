using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Respawn")]
    public Crashpod crashpod;
    public string crashpodTag = "Crashpod";
    public float respawnDelay = 0.5f;

    [Header("UI")]
    public PlayerHealthUI healthUI;   // Add this reference

    bool isDead;

    void Awake()
    {
        currentHealth = Mathf.Max(1, maxHealth);

        if (crashpod == null)
        {
            var podGO = GameObject.FindGameObjectWithTag(crashpodTag);
            if (podGO) crashpod = podGO.GetComponent<Crashpod>();
        }

        if (healthUI != null)
            healthUI.Setup(maxHealth, currentHealth);  // Initialize UI
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(25);
        if (Input.GetKeyDown(KeyCode.K)) Kill();
    }

    public void TakeDamage(int dmg)
    {
        if (isDead) return;
        currentHealth -= Mathf.Max(0, dmg);
        Debug.Log($"[PlayerHealth] Took {dmg}. Now {currentHealth}/{maxHealth}");

        if (healthUI != null)
            healthUI.UpdateHealth(currentHealth);  // Update UI here

        if (currentHealth <= 0) Die();
    }

    public void Kill() => Die();

    void Die()
    {
        if (isDead) return;
        isDead = true;
        Debug.Log("[PlayerHealth] DIED");
        Invoke(nameof(Respawn), respawnDelay);
    }

    void Respawn()
    {
        if (crashpod != null)
        {
            transform.position = crashpod.GetSpawnPoint();
            Debug.Log("[PlayerHealth] Respawned at Crashpod");
        }
        else
        {
            Debug.LogWarning("[PlayerHealth] Crashpod not set/found. Staying in place.");
        }

        currentHealth = maxHealth;

        if (healthUI != null)
            healthUI.UpdateHealth(currentHealth);  // Reset UI on respawn

        isDead = false;
    }
}
