using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HazardTrigger2D : MonoBehaviour
{
    public int damageOnEnter = 20;
    public float damagePerSecond = 0f; // set > 0 if you want DoT while inside

    void Reset()
    {
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var hp = other.GetComponent<PlayerHealth>();
        if (hp) hp.TakeDamage(damageOnEnter);
    }

    float timer;
    void OnTriggerStay2D(Collider2D other)
    {
        if (damagePerSecond <= 0f) return;
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0f;
            var hp = other.GetComponent<PlayerHealth>();
            if (hp) hp.TakeDamage(Mathf.RoundToInt(damagePerSecond));
        }
    }
}
