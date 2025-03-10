using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

public class GameController : MonoBehaviour
{
    // This will store the checkpoint position.
    //private Vector2 checkpointPos;

    // Dictionary to store checkpoints per scene.
    private static Dictionary<int, Vector2> sceneCheckpoints = new Dictionary<int, Vector2>();


    // Reference to the player GameObject (assign via Inspector)
    public GameObject player;

    // Store player's original scale to hide/show on death
    private Vector3 playerOriginalScale;

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

    void Awake()
    {
        if (player == null && PersistentPlayer.Instance != null)
        {
            player = PersistentPlayer.Instance.gameObject;
            UnityEngine.Debug.Log("Player assigned from PersistentPlayer.");
        }
        else if (player == null)
        {
            UnityEngine.Debug.LogError("Player not assigned in GameController!");
        }
        // Ensure the die particle effect persists across scenes if it is assigned
        if (dieParticleEffect != null)
        {
            DontDestroyOnLoad(dieParticleEffect.gameObject);
        }
    }

    //void Start() //old with die particles and check persistent player
    //{
    //    if (player == null && PersistentPlayer.Instance != null)
    //    {
    //        player = PersistentPlayer.Instance.gameObject;
    //        checkpointPos = player.transform.position;
    //        playerOriginalScale = player.transform.localScale;
    //        UnityEngine.Debug.Log("GameController: Player set to persistent instance.");
    //    }
    //    else if (player != null)
    //    {
    //        checkpointPos = player.transform.position;
    //        playerOriginalScale = player.transform.localScale;
    //    }

    //    // If the die particle effect hasn't been assigned via the Inspector,
    //    // try to find it on the player prefab.
    //    if (dieParticleEffect == null && player != null)
    //    {
    //        dieParticleEffect = player.GetComponentInChildren<ParticleSystem>();
    //        if (dieParticleEffect == null)
    //        {
    //            UnityEngine.Debug.LogError("Die Particle Effect not found on the player prefab!");
    //        }
    //        else
    //        {
    //            // Make sure it's persistent if found at runtime.
    //            DontDestroyOnLoad(dieParticleEffect.gameObject);
    //        }
    //    }
    //}


    void Start()
    {
        if (player != null)
        {
            // Keep the player’s initial position/scale if needed
            playerOriginalScale = player.transform.localScale;
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
        if (whiteScreenAnimation != null)
        {
            whiteScreenAnimation.Play("die_white_screen");
        }
        else
        {
            UnityEngine.Debug.LogError("White Screen Animation not assigned in GameController!");
        }

        // Deduct one life from the persistent player's lives.
        if (PersistentPlayer.Instance != null)
        {
            PlayerLivesManager livesManager = PersistentPlayer.Instance.GetComponent<PlayerLivesManager>();
            if (livesManager != null)
            {
                livesManager.DeductLife();
            }
            else
            {
                UnityEngine.Debug.LogError("PlayerLivesManager component not found on PersistentPlayer.");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("PersistentPlayer instance not found.");
        }

        // Trigger the die particle effect at the player's current position.
        if (DieParticleManager.Instance != null)
        {
            // Use the player's position at the time of hit.
            DieParticleManager.Instance.PlayDieEffect(player.transform.position);
        }
        else
        {
            UnityEngine.Debug.LogError("DieParticleManager instance not found!");
        }

        StartCoroutine(Respawn(0.5f));
    }

    // Called by a checkpoint to update the checkpoint position.
    //public void UpdateCheckpoint(Vector2 pos)
    //{
    //    checkpointPos = pos;
    //    UnityEngine.Debug.Log("Checkpoint updated to: " + checkpointPos);
    //}

    public void UpdateCheckpoint(Vector2 pos)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        sceneCheckpoints[currentScene] = pos;
        UnityEngine.Debug.Log("Checkpoint for scene " + currentScene + " updated to: " + pos);
    }

    IEnumerator Respawn(float duration)
    {
        // Attempt to reassign the player from the persistent instance if it's null.
        if (player == null && PersistentPlayer.Instance != null)
        {
            player = PersistentPlayer.Instance.gameObject;
            // Also update the Rigidbody2D reference from the persistent player.
            PlayerRb = player.GetComponent<Rigidbody2D>();
            UnityEngine.Debug.Log("Player reassigned from persistent instance.");
        }

        // Make the player invisible by scaling to zero.
        if (player != null)
        {
            player.transform.localScale = Vector3.zero;
        }

        if (PlayerRb != null)
        {
            PlayerRb.linearVelocity = Vector2.zero;
            PlayerRb.simulated = false;
        }

        // Wait for the respawn delay.
        yield return new WaitForSeconds(duration);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Vector2 respawnPos;

        // Check if we have a checkpoint stored for this scene
        if (!sceneCheckpoints.TryGetValue(currentScene, out respawnPos))
        {
            // If not, find the local PlayerStart
            GameObject startPoint = GameObject.FindGameObjectWithTag("PlayerStart");
            if (startPoint != null)
            {
                respawnPos = startPoint.transform.position;
            }
            else
            {
                // Default to (0,0) if there's no PlayerStart
                respawnPos = Vector2.zero;
            }
        }

        // Move player to the respawn position and restore scale
        if (player != null)
        {
            player.transform.position = respawnPos;
            player.transform.localScale = playerOriginalScale;
        }
        if (PlayerRb != null)
            PlayerRb.simulated = true;
    }
}

// If no checkpoint was set (e.g., remains (0,0)), try to get the default PlayerStart position.
// if (checkpointPos == Vector2.zero)
//        {
//            GameObject startPoint = GameObject.FindGameObjectWithTag("PlayerStart");
//            if (startPoint != null)
//            {
//                checkpointPos = startPoint.transform.position;
//                UnityEngine.Debug.Log("No checkpoint updated, defaulting to PlayerStart position: " + checkpointPos);
//            }
//            else
//            {
//                UnityEngine.Debug.LogWarning("No PlayerStart object found; using (0,0) as default.");
//            }
//        }

//        // Move the player to the checkpoint and restore the original scale.
//        if (player != null)
//        {
//            player.transform.position = checkpointPos;
//            player.transform.localScale = playerOriginalScale;
//        }
//        else
//        {
//            UnityEngine.Debug.LogError("Player not assigned in GameController!");
//        }
//
//        if (PlayerRb != null)
//        {
//            PlayerRb.simulated = true;
//        }
//    }
//}