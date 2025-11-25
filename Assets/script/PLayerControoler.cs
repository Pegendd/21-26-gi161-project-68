using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float MoveX;
    private float MoveY;

    [SerializeField] private Animator PlayerAnimator;


    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private bool isGrounded = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown (KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
            isGrounded = false ;
            
        }

        PlayerAnimator.SetBool("IsRunning" , MoveX != 0);

        PlayerAnimator.SetBool("IsGround" , isGrounded);






    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(MoveX,MoveY ).normalized;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.collider.CompareTag("Ground")) isGrounded = true;
    }
}