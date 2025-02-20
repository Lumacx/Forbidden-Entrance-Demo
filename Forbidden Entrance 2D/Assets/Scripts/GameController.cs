using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;

public class GameController : MonoBehaviour
{
    // This will store the checkpoint position.
    private Vector2 checkpointPos;

    // Reference to the player GameObject (assign via Inspector)
    public GameObject player;

    // Reference to the player's Rigidbody2D (assign via Inspector)
    public Rigidbody2D PlayerRb;

    // Define an array of tags that should trigger Die()
    private readonly string[] dangerousTags = { "Respawn", "Enemy", "Obstacle" };

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
        }
    }

    void Die()
    {
        // (Optional: Trigger animations or particles here)
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
    }
}
