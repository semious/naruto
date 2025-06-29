using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    [Header("Player Core Component")]
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject ground;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Collision")]
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private bool isFacingRight = true;
    private bool canMove = true;
    private bool isAttacking = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = body.GetComponent<Animator>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        //    Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //SyncPlayerPosition();

        HandleUserInputs();

        HandleAnimation();

        HandleFlip();


    }

    public void setMovement(bool enable)
    {
        this.canMove = enable;
    }

    public void setAttack(bool enable)
    {
        this.isAttacking = enable;
    }

    //private void HandleCollision()
    //{
    //    isGrounded = Physics2D.Raycast(body.transform.position, Vector2.down, groundCheckDistance, groundLayer);
    //}

    private void HandleUserInputs()
    {
        TryToMove();
        TryToAttack();
        //HandleJump(rb);

    }

    private void HandleAnimation()
    {
        float xVelocity = rb.velocity.x;
        float yVelocity = rb.velocity.y;

        float velocityMagnitude = new Vector2(xVelocity, yVelocity).magnitude;
        anim.SetFloat("velocity", velocityMagnitude);
    }

    private void TryToMove()
    {

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (canMove)
            rb.velocity = new Vector2(xInput * moveSpeed, yInput * moveSpeed);
        else
            rb.velocity = Vector2.zero;


    }

    private void TryToAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            anim.SetTrigger("attack");
        }
    }

    //private void HandleJump(Rigidbody2D rb)
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    //        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //}



    private void HandleFlip()
    {
        if (rb.velocity.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        rb.transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    //private void SyncPlayerPosition()
    //{


    //    //Debug.Log($"Distance to ground: {distanceToGround}");

    //    Vector3 groundPosition = ground.transform.position;
    //    groundPosition.x = body.transform.position.x;
    //    groundPosition.y = body.transform.position.y - distanceToGround;
    //    ground.transform.position = groundPosition;

    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    //}
}
