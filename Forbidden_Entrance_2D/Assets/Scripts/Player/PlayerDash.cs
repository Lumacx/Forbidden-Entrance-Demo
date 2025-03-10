using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerMovement _player;
    private float _baseGravity;
    private Animator animator; // Animator reference added

    [Header("Dash Settings")]
    [SerializeField] private float _dashingTime = 0.2f;   // Duration of the dash
    [SerializeField] private float _dashForce = 20f;        // Force applied during dash
    [SerializeField] private float _timeCanDash = 2f;       // Cooldown period before the next dash is allowed

    [SerializeField] private TrailRenderer trailRenderer;

    private bool _isDashing;
    private bool _canDash = true;
    // Optional flag to ensure the dash key is released before the next dash can occur.
    private bool _dashKeyReleased = true;

    // Public properties for external access (if needed)
    public bool IsDashing => _isDashing;
    public bool CanDash => _canDash;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>(); // Initialize animator
        _baseGravity = _rb.gravityScale;
    }

    void Update()
    {
        // Optional: Check if dash key is released to allow another dash.
        if (Input.GetKeyUp(KeyCode.E))
        {
            _dashKeyReleased = true;
        }

        // Trigger dash only if dash is available, dash key has been released,
        // and the player presses E.
        if (Input.GetKeyDown(KeyCode.E) && _canDash && _dashKeyReleased)
        {
            // Reset the key released flag to prevent immediate re-triggering.
            _dashKeyReleased = false;
            StartCoroutine(Dash());
            SFX_Manager.Play("swoosh");
        }
    }

    private IEnumerator Dash()
    {
        // Determine dash direction:
        // If there's horizontal input from PlayerMovement, use it;
        // Otherwise, use the current facing direction based on localScale.
        float dashDirection = _player.Direction != 0 ? _player.Direction : (transform.localScale.x > 0 ? 1f : -1f);

        _isDashing = true;
        _canDash = false;

        // Trigger the dash animation.
        animator.SetTrigger("Dash");
        
        // Enable the trail to visually indicate the dash.
        if (trailRenderer != null)
        {
            trailRenderer.emitting = true;
        }

        // Disable gravity during dash to avoid vertical interference.
        _rb.gravityScale = 0f;

        // Apply a high horizontal velocity for the dash.
        _rb.linearVelocity = new Vector2(dashDirection * _dashForce, 0f);
        
        // Wait for the dash duration.
        yield return new WaitForSeconds(_dashingTime);

        _isDashing = false;
        // Restore original gravity.
        _rb.gravityScale = _baseGravity;

        // Disable the trail once dash is complete.
        if (trailRenderer != null)
        {
            trailRenderer.emitting = false;
        }
        // Optional: Reset horizontal velocity if desired.
        // _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);

        // Wait for the cooldown period before allowing the next dash.
        yield return new WaitForSeconds(_timeCanDash);
        _canDash = true;
        
    }
}
