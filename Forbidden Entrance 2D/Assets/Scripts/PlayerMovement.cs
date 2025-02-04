using System;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 7f;  // Horizontal movement speed
    public float jumpForce = 10f;  // Force for a quick (tap) jump

    [Header("Jump Settings")]
    public float maxMultiplier = 1.5f;         // Total jump force multiplier when holding jump
    public float maxHoldTime = 0.5f;           // Maximum duration for additional force application
        
    private float jumpHoldCounter;           // Counter for how long the jump key is held
    private bool isJumping = false;          // Flag to track if the jump is in progress

    [Header("Ground Check Settings")]
    public Transform groundCheck;            // Transform for ground check (assign in Inspector)
    public float groundCheckRadius = 0.7f;     // Radius of the ground check circle
    public LayerMask groundLayer;            // Layer(s) considered as ground

    [Header("Raycast Settings")]
    public Vector2 boxSize; //use on Raycast
    public float castDistance; //use on Raycast

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool facingRight = true;
    public float Direction => horizontalInput;  // Exposed for use in dash logic
    private PlayerDash _playerDash;    // Reference to the dash component

    private Animator animator;
    
    void Awake()
    {
        _playerDash = GetComponent<PlayerDash>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer); //**old version that double jump **

        // Get horizontal input every frame
        horizontalInput = Input.GetAxis("Horizontal");

        // Only process jump and animation updates if not dashing
          if (!_playerDash.IsDashing)
         { 
            // Start jump on Space key press when grounded
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                isJumping = true;
                jumpHoldCounter = maxHoldTime;

                // Apply the base jump impulse
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                animator.SetBool("jumping", true);

            }
            else if (isGrounded())
            {
                animator.SetBool("jumping", false);
            }

            // Update running animation and flip character based on horizontal input
            if (horizontalInput != 0)
            {
                animator.SetBool("running", true);
                Flip(horizontalInput);
            }
            else
            {
                animator.SetBool("running", false);
            }

            {
              // Cancel additional jump if the key is released early
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    isJumping = false;
                }
            }
        }

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // Update horizontal movement only if not currently dashing.
        if (!_playerDash.IsDashing)
        { 
            rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
          }

        // While the jump key is held and within allowed hold time, apply extra upward force
        if (isJumping && jumpHoldCounter > 0)
        {
            // Calculate additional impulse per FixedUpdate frame.
            // Total extra impulse needed is: (maxMultiplier - 1) * baseJumpForce.
            // Distributed over maxHoldTime, per frame extra impulse is:
            float extraImpulsePerFrame = ((maxMultiplier - 1f) * jumpForce / maxHoldTime) * Time.fixedDeltaTime;

            // Apply the extra impulse using AddForce with Impulse mode
            rb.AddForce(new Vector2(0, extraImpulsePerFrame), ForceMode2D.Impulse);

            jumpHoldCounter -= Time.fixedDeltaTime;
        }

    }


    //Raycast Method to validate Collision

    public bool isGrounded ()
    {
     if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
     {
            return true;
        }
        else { return false; }
    }
    
    // Visualize the ground detection box in the Scene view
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position -transform.up * castDistance, boxSize);
    }
    
    // Optional: Visualize the ground check in the editor for debugging purposes.
    
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    // Flip the character's facing direction based on horizontal input
    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    
}