using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutBounds : MonoBehaviour

{
    public int Respawn; //Restart the scene after player fall out of bounds

    void Start()
    {


    }

    void Update()

    {

    }

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Respawn); //Scene 0 = first one to Respawn, modify Respawn to scene number if applied
        }
    }

}
