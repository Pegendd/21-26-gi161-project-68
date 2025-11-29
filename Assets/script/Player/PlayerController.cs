using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float MoveX;
    private float MoveY;

    [SerializeField] private Animator PlayerAnimator;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private bool isGrounded = true;
    public bool facingRight = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FlipController()
    {
       
        if (rb.linearVelocity.x < 0 && facingRight)
        {
            Flip();
        }
        else if (rb.linearVelocity.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");

       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        FlipController();

      
        if (PlayerAnimator != null) 
        {
            PlayerAnimator.SetBool("IsRunning", MoveX != 0);
            PlayerAnimator.SetBool("IsGround", isGrounded);
        }
    }

    void FixedUpdate()
    {
       
        rb.linearVelocity = new Vector2(MoveX * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}