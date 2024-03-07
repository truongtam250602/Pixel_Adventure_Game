using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
   public static PlayerController Instance;

    [Header("Move Settings")]
    [SerializeField] private float jumpForce = 16.0f;
    [SerializeField] private float speed = 8.0f;
    [SerializeField] private LayerMask jumpableGround;

    private int orangesCollected = 0;

    private enum MovementState { idle, running, jumping, falling}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
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

    void PlayerMovement()
    {
        MovementState state;
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (dirX != 0)
        {
            state = MovementState.running;
            if (dirX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (dirX > 0)
            {
                transform.localScale = Vector3.one;
            }
        }
        else
        {
            state = MovementState.idle;
        }
        
        if(rb.velocity.y < -0.01f)
        {
            state = MovementState.falling;
        }
        else if(rb.velocity.y > 0.01f)
        {
            state = MovementState.jumping;
        }

        anim.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
