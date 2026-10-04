using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public HealtUI healthUI;
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
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        // Aggiorna cuori
        healthUI.UpdateHearts(currentHealth, maxHealth);

        // Se muore → respawn totale
        if (currentHealth == 0)
        {
            FullRespawn();
        }
    }

    void FullRespawn()
    {
        // Teletraspota allo spawn
        transform.position = respawnPoint.position;

        // Reset movimento
        rb.linearVelocity = Vector2.zero;

        // Ripristina cuori
        currentHealth = maxHealth;
        healthUI.UpdateHearts(currentHealth, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // DEATHZONE = one-shot
        if (collision.CompareTag("DeathZone"))
        {
            currentHealth = 0;
            FullRespawn();
        }
    }
    public void SetCheckpoint(Transform newCheckpoint)
    {
        respawnPoint = newCheckpoint;
    }

}
