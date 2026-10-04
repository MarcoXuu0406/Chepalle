using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint;
    PlayerHealth health;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
    }

    public void Respawn()
    {
        transform.position = spawnPoint.position;
        health.currentHealth = health.maxHealth;
    }
}
