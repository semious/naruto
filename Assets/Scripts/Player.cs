using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    public PlayerInputSet input { get; private set; }
    private StateMachine stateMachine;

    public Player_IdelState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Player_BasicAttackState basicAttackState { get; private set; }


    [Header("Movement Details")]
    public float moveSpeed;
    public Vector2 moveInput { get; private set; }
    private bool facingRight = true;
    public int facingDir { get; private set; } = 1;


    [Header("Attack Details")]
    public Vector2[] attackVelocity;
    public float attackVelocityDuration = .1f;
    public float attackComboResetTime = 0.5f; // Cooldown for basic combo attack


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        input = new PlayerInputSet();

        idleState = new Player_IdelState(this, stateMachine, "idle");
        moveState = new Player_MoveState(this, stateMachine, "move");
        basicAttackState = new Player_BasicAttackState(this, stateMachine, "basicAttack");
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        //Debug.Log($"moveInput.x: {moveInput.x}");
        stateMachine.UpdateActiveState();
    }

    public void CallAnimationTrigger()
    {
        stateMachine.currentState.CallAnimationTrigger();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        HandleFlip(xVelocity);
        rb.velocity = new Vector2(xVelocity, yVelocity);
    }

    public void HandleFlip(float xVelocity)
    {
        if (xVelocity > 0 && !facingRight)
        {
            Flip();
        }
        else if (xVelocity < 0 && facingRight)
        {
            Flip();
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;
        facingDir *= -1;
        transform.Rotate(0, 180, 0);
    }
}
