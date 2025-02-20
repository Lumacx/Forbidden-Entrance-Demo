using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class itemsProgress : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    public GameObject player;
    public GameObject LoadCanvas;

    // New: Animator for transition animation and time to wait before scene load
    public Animator transition;
    public float transitionTime = 1f;

    // Flag to determine if the player is touching the Portal collider
    private bool isTouchingPortal = false;


    //Start monitoring items progress
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        // Subscribe to events (ensure Gem and HoldToLoadLevel events exist in your project)
        Gem.OnGemCollect += IncreaseProgressAmount;
        HoldToLoadLevel.OnHoldComplete += LoadNextLevel;
        LoadCanvas.SetActive(false);
    }

    void IncreaseProgressAmount (int amount)

    {
        progressAmount += amount;
        progressSlider.value = progressAmount;
        // Show LoadCanvas only if progress is at least 100 and player is touching the Portal
        if (progressAmount >= 100 && isTouchingPortal)
        {
            // Level complete: show the load canvas and log a message
            LoadCanvas.SetActive(true);
            UnityEngine.Debug.Log("Level Complete");
        }
    }

    // This method is called when the hold event is complete (from your HoldToLoadLevel script)
    void LoadNextLevel()
    {
        // Start the coroutine to load the next scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play the transition animation
        if (transition != null)
        {
            transition.SetTrigger("Start");
        }

        // Wait for the transition to finish
        yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        SceneManager.LoadScene(levelIndex);
    }

    // When the player enters a Portal collider, set the flag and show the LoadCanvas if progress is high enough.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //UnityEngine.Debug.Log("Trigger Enter: " + collision.gameObject.name + ", Tag: " + collision.tag);
        if (collision.CompareTag("Portal"))
        {
            isTouchingPortal = true;
            if (progressAmount >= 100)
            {
                LoadCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //UnityEngine.Debug.Log("Trigger Exit: " + collision.gameObject.name + ", Tag: " + collision.tag);
        if (collision.CompareTag("Portal"))
        {
            isTouchingPortal = false;
            LoadCanvas.SetActive(false);
        }
    }
}