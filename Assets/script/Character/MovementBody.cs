using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;
    public float jumpForce = 7f;
    public float doubleJumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool canDoubleJump;
    private float moveInput;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (rb == null) Debug.LogError("[PlayerMovement] Rigidbody2D mancante sul Player!");
        if (groundCheck == null) Debug.LogWarning("[PlayerMovement] groundCheck NON assegnato in Inspector!");
        rb.freezeRotation = true;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Detect ground
        if (groundCheck != null)
        {
            bool wasGrounded = isGrounded;
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            if (isGrounded != wasGrounded)
                Debug.Log($"[PlayerMovement] Grounded changed: {isGrounded}");
        }
        else
        {
            isGrounded = false;
        }

        // Reset doppio salto
        if (isGrounded)
            canDoubleJump = true;

        // JUMP + DOUBLE JUMP
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            Debug.Log("[PlayerMovement] Jump input detected. isGrounded=" + isGrounded + " canDoubleJump=" + canDoubleJump);

            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

                if (animator != null)
                    animator.SetTrigger("isJump"); // Trigger salto
            }
            else if (canDoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJumpForce);
                canDoubleJump = false;

                if (animator != null)
                    animator.SetTrigger("isJump"); // Trigger salto doppio
            }
        }

        // Flip direzione
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // ---------------------------
        //     SISTEMA ANIMAZIONI
        // ---------------------------
        if (animator != null)
        {
            animator.SetBool("isRunning", moveInput != 0);
            animator.SetBool("isGrounded", isGrounded);
            animator.SetFloat("yVelocity", rb.linearVelocity.y);

            // Stato salto / caduta
            if (!isGrounded)
            {
                if (rb.linearVelocity.y > 0.1f)
                {
                    animator.SetBool("isJumping", true);
                    animator.SetBool("isFalling", false);
                }
                else if (rb.linearVelocity.y < -0.1f)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", true);
                }
            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
            }
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
            rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
