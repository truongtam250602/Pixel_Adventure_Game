using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX;
    public float dirY;

    [Header("Move Settings")]
    [SerializeField] private float jumpForce = 16.0f;
    [SerializeField] private float speed = 8.0f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private ParticleSystem dushParticle;

    private bool doubleJump;
    private bool isSliding;
    private bool wallJumping;
    [Header("Wall Jump Settings")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallSlidingSpeed;
    [SerializeField] private float wallJumpingDuration;
    [SerializeField] private Vector2 wallJumpForce;

    private enum MovementState { idle, running, jumping, falling, sliding}
    AudioManager audioManager;

    private void Awake()
    {
        Instance = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        if(wallJumping)
        {
            rb.velocity = new Vector2(-dirX * wallJumpForce.x, wallJumpForce.y);
        }
    }
    void PlayerMovement()
    {
        MovementState state;
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        // wall jump set is Sliding value
        if(IsWallTouch() && !IsGrounded() && dirX != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }
        // jump
        if (Input.GetButtonDown("Jump"))
        {
            if (doubleJump && !IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetTrigger("Double Jump");
                doubleJump = false;
                audioManager.PlaySFX(audioManager.jumpAudio);
            }
            //jump on grounded
            else if(IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = true;
                audioManager.PlaySFX(audioManager.jumpAudio);
            }
            else if (IsWallTouch()) // jump wall
            {
                wallJumping = true;
                doubleJump = true;
                Invoke("StopWallJump", wallJumpingDuration);
                audioManager.PlaySFX(audioManager.jumpAudio);
            }


        }

        if (dirX != 0)
        {
            state = MovementState.running;
            dushParticle.gameObject.SetActive(true);
        }
        else
        {
            state = MovementState.idle;
            dushParticle.gameObject.SetActive(false);
        }
        
        if(rb.velocity.y < -0.01f && !IsWallTouch() && !IsGrounded())
        {
            state = MovementState.falling;
        }
        else if(rb.velocity.y > 0.01f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.01f && IsWallTouch())
        {
            state = MovementState.sliding;
        }
        
        anim.SetInteger("State", (int)state);

        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private bool IsWallTouch()
    {
        return Physics2D.OverlapBox(wallCheck.position, new Vector2(.2f, 1f), 0, jumpableGround);
    }
    private void StopWallJump()
    {
        wallJumping = false;
    }
    private void Flip()
    {
        if (dirX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dirX > 0)
        {
            transform.localScale = Vector3.one;
        }
    }
}
