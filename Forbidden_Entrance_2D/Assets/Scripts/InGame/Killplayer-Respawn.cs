using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutBounds : MonoBehaviour

{
     GameController gameController;
    public Transform respawnPoint;


    private void Awake()
    {
        gameController= GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
    }
    
    //public int Respawn; //Restart the scene after player fall out of bounds

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Player"))
        {
            gameController.UpdateCheckpoint(respawnPoint.position);
        }
    }

}
