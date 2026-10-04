using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();

            if (health != null)
            {
                // invece di usare maxHearts, ora usiamo maxHealth
                health.TakeDamage(health.maxHealth);
            }
        }
    }
}
