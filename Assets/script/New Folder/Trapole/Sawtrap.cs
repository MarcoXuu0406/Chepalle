using UnityEngine;

public class Saw : MonoBehaviour
{
    [Header("Rotazione")]
    public float rotateSpeed = 300f;

    [Header("Danno al Player")]
    public int damage = 2; // toglie 2 cuori

    void Update()
    {
        // Rotazione costante della sega
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
