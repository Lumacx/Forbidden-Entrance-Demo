using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{
    // This will store the checkpoint position.
    private Vector2 checkpointPos;

    // Reference to the player GameObject (assign via Inspector)
    public GameObject player;
    
    private Vector3 playerOriginalScale;

    void Awake()
    {
        playerOriginalScale = player.transform.localScale; // Store the original scale at startup.
    }
    
    // Reference to the player's Rigidbody2D (assign via Inspector)
    public Rigidbody2D PlayerRb;

    // Define an array of tags that should trigger Die()
    private readonly string[] dangerousTags = { "Respawn", "Enemy", "Obstacle" };

    // Direct references to your visual effects:
    [Header("Death Effects")]
    // Reference to the white screen animation (attach the Animation component on your white screen object)
    public Animation whiteScreenAnimation;
    // Reference to the die particle effect (attach the ParticleSystem component on your die effect object)
    public ParticleSystem dieParticleEffect;

    void Start()
    {
        // Initialize checkpoint to the player's starting position.
        if (player != null)
        {
            checkpointPos = player.transform.position;
        }
        else
        {
            UnityEngine.Debug.LogError("Player not assigned in GameController!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision tag exists in dangerousTags.
        if (dangerousTags.Contains(collision.tag))
        {
            Die();
            SFX_Manager.Play("PlayerHit");
        }
    }

    void Die()
    {
        // Play the white screen animation if it's assigned
        if (whiteScreenAnimation != null)
        {
            whiteScreenAnimation.Play("die_white_screen");
        }
        else
        {
            UnityEngine.Debug.LogError("White Screen Animation not assigned in GameController!");
        }

        // Play the die particle effect if it's assigned
        if (dieParticleEffect != null)
        {
            dieParticleEffect.Play();
        }
        else
        {
            UnityEngine.Debug.LogError("Die Particle Effect not assigned in GameController!");
        }

        // Optionally, trigger any additional animations or effects here

        StartCoroutine(Respawn(0.5f));
    }

    // Called by a checkpoint to update the checkpoint position.
    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
        UnityEngine.Debug.Log("Checkpoint updated to: " + checkpointPos);
    }

    IEnumerator Respawn(float duration)
    {
        // Make the player invisible when dying
        player.transform.localScale = Vector3.zero;
        //transform.localScale = new Vector3(0, 0, 0);

        if (PlayerRb != null)
        {
            PlayerRb.linearVelocity = Vector2.zero;
            PlayerRb.simulated = false;
        }

        // Wait for the respawn delay.
        yield return new WaitForSeconds(duration);

        // Move the player to the updated checkpoint position.
        if (player != null)
        {
            player.transform.position = checkpointPos;
        }
        else
        {
            UnityEngine.Debug.LogError("Player not assigned in GameController!");
        }

        if (PlayerRb != null)
        {
            PlayerRb.simulated = true;
        }
         // Restore the player's original scale (preserving flip if needed)
        player.transform.localScale = playerOriginalScale;
    }
}
