using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damage = 1;            // Danno inflitto
    public float damageInterval = 1f; // Ogni 1 secondo

    private bool playerInside = false;
    private float damageTimer = 0f;

    private PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;

            if (playerHealth == null)
                playerHealth = collision.GetComponent<PlayerHealth>();

            // Danno immediato al contatto
            playerHealth.TakeDamage(damage);

            // Reset timer
            damageTimer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    private void Update()
    {
        if (playerInside && playerHealth != null)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                playerHealth.TakeDamage(damage);
                damageTimer = 0f;
            }
        }
    }
}
