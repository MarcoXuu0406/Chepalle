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

        rb.freezeRotation = true;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // -------------------------
        //     GROUND CHECK
        // -------------------------
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Quando tocchi terra → attiva landing
        if (!wasGrounded && isGrounded)
        {
            animator.SetBool("isLanding", true);
        }

        // Reset doppio salto quando tocca terra
        if (isGrounded)
            canDoubleJump = true;

        // -------------------------
        //         SALTO
        // -------------------------
        if (Input.GetButtonDown("Jump"))
        {
            // Primo salto
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                animator.SetBool("isJumping", true);
            }
            // Doppio salto
            else if (canDoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJumpForce);
                animator.SetBool("isJumping", true);
                canDoubleJump = false;
            }
        }

        // -------------------------
        //     FLIP DIREZIONE
        // -------------------------
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);

        // -------------------------
        //  AGGIORNA PARAMETRI ANIMATOR
        // -------------------------

        animator.SetBool("isRunning", Mathf.Abs(moveInput) > 0.1f);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

        // Salto e Caduta
        if (!isGrounded)
        {
            if (rb.linearVelocity.y > 0.1f)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
                animator.SetBool("isLanding", false);
            }
            else if (rb.linearVelocity.y < -0.1f)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
                animator.SetBool("isLanding", false);
            }
        }
        else
        {
            // A terra → niente Jump/Fall
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }

    void FixedUpdate()
    {
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
}
