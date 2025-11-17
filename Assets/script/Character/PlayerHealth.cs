using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;     // quante vite totali (cuori)
    public int currentHealth;

    public HealtUI healthUI;      // UI dei cuori
    public Transform respawnPoint;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthUI.UpdateHearts(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        // Perde 1 cuore
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        // Aggiornamento UI
        healthUI.UpdateHearts(currentHealth, maxHealth);

        // Se finisce i cuori → respawn totale
        if (currentHealth == 0)
        {
            Die();
        }
        else
        {
            RespawnWithoutResettingLives();
        }
    }

    void RespawnWithoutResettingLives()
    {
        // Respawn ma NON ristoro le vite
        transform.position = respawnPoint.position;
        rb.linearVelocity = Vector2.zero;
    }

    void Die()
    {
        // Respawn totale e ricarica cuori
        transform.position = respawnPoint.position;
        rb.linearVelocity = Vector2.zero;

        currentHealth = maxHealth;
        healthUI.UpdateHearts(currentHealth, maxHealth);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            // La DeathZone ora toglie SOLO 1 vita
            TakeDamage(1);
        }
    }
}
