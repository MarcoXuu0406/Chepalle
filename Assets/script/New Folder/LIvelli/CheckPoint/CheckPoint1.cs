using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isActivated = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isActivated", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActivated && collision.CompareTag("Player"))
        {
            PlayerHealth hp = collision.GetComponent<PlayerHealth>();
            hp.SetCheckpoint(transform);
            Debug.Log("Triggerato");

            Activate();
        }
    }

    void Activate()
    {
        isActivated = true;
        animator.SetBool("isActivated", true);
    }
}
