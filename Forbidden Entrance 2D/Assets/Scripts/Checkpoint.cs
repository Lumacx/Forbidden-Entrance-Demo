using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameController gameController;
    public Transform respawnPoint;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    Collider2D coll;

    private void Awake()
    {
        // Use FindAnyObjectByType to get any instance of GameController
        gameController = UnityEngine.Object.FindAnyObjectByType<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameController != null)
            {
                gameController.UpdateCheckpoint(respawnPoint.position);
                spriteRenderer.sprite = active;
                coll.enabled = false;
                UnityEngine.Debug.Log("Player hit checkpoint. New respawn point: " + respawnPoint.position);
            }
            else
            {
                UnityEngine.Debug.LogError("GameController not found in the scene.");
            }
        }
    }
}
