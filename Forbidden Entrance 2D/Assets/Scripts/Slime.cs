using UnityEngine;

public class slimeMovement : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 1.0f;
    public float jumpForce = 3f;
    public float detectionRange = 5f; // Maximum distance for detection
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if enemy is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // Calculate distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Only chase if the player is within the detection range and enemy is grounded
        if (distanceToPlayer <= detectionRange && isGrounded)
        {
            // Determine direction (1 if player is to the right, -1 if to the left)
            float direction = Mathf.Sign(player.position.x - transform.position.x);
            SFX_Manager.Play("slime");

            // Flip the enemy by modifying localScale.x
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            transform.localScale = scale;


            // Set horizontal velocity to chase the player
            rb.linearVelocity = new Vector2(direction * chaseSpeed, rb.linearVelocity.y);

            // Check for jump conditions

            // Player above detection (using player's layer)
            bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, 1 << player.gameObject.layer);

            // Check ground in front of enemy
            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);

            // Check for gap ahead
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 2f, groundLayer);

            // Check for platform above
            RaycastHit2D platformAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, groundLayer);

            if (!groundInFront.collider && !gapAhead.collider)
            {
                shouldJump = true;
            }
            else if (isPlayerAbove && platformAbove.collider)
            {
                shouldJump = true;
            }
        }
        else
        {
            // Player is out of detection range or enemy is not grounded: idle behavior
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            shouldJump = false;
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded && shouldJump)
        {
            shouldJump = false;
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 jumpDirection = direction * jumpForce;
            rb.AddForce(new Vector2(jumpDirection.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the enemy collides with the respawn collider
        if (collision.CompareTag("Respawn"))
        {
            // Destroy the enemy GameObject
            Destroy(gameObject);
        }
    }
}
