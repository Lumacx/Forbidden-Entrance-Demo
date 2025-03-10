using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;

public class itemsProgress : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    public GameObject player;
    public GameObject LoadCanvas;  // This should be a child of the player

    public Animator transition;
    public float transitionTime = 1f;

    private bool isTouchingPortal = false;

    [Header("Celestia (Lives) Settings")]
    public int celestiaCount = 3;         // Starting lives (Celestia)

    [Header("Gem to Extra Life Settings")]
    public int gemsForExtraLife = 100;    // Gems needed to gain one extra life
    private int totalGemsCollected = 0;   // Accumulate total gems collected

    [Header("UI References")]
    public TMP_Text celestiaText;         // Displays the current lives
    public TMP_Text gemProgressText;      // Displays the number of extra lives earned from gems

    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;

        // Automatically assign the persistent player if not set.
        if (player == null && PersistentPlayer.Instance != null)
        {
            player = PersistentPlayer.Instance.gameObject;
            UnityEngine.Debug.Log("ItemsProgress: Player assigned from persistent instance.");
        }

        // Auto-assign LoadCanvas if it's not set in the Inspector.
        if (LoadCanvas == null)
        {
            if (player != null)
            {
                Transform loadCanvasTransform = player.transform.Find("LoadCanvas");
                if (loadCanvasTransform != null)
                {
                    LoadCanvas = loadCanvasTransform.gameObject;
                    UnityEngine.Debug.Log("ItemsProgress: LoadCanvas assigned from player child.");
                }
                else
                {
                    UnityEngine.Debug.LogError("LoadCanvas not found as a child of the player. Please assign it in the Inspector or add it as a child named 'LoadCanvas'.");
                }
            }
            else
            {
                UnityEngine.Debug.LogError("Player not assigned, cannot auto-assign LoadCanvas.");
            }
        }

        // Subscribe to events
        Gem.OnGemCollect += IncreaseProgressAmount;
        //HoldToLoadLevel.OnHoldComplete += LoadNextLevel;

        // Hide the LoadCanvas at start if it exists.
        if (LoadCanvas != null)
        {
            LoadCanvas.SetActive(false);
        }
        // Initialize UI texts.
        if (celestiaText != null)
            celestiaText.text = " " + celestiaCount.ToString();
        if (gemProgressText != null)
            gemProgressText.text = " 0";
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        totalGemsCollected += amount; // Accumulate all collected gems.
        progressSlider.value = progressAmount;

        // When progress reaches the threshold, award extra lives.
        if (progressAmount >= gemsForExtraLife)
        {
            int extras = progressAmount / gemsForExtraLife; // How many extra lives to award.
            celestiaCount += extras;
            // Play the powerup sound for each extra life awarded.
            for (int i = 0; i < extras; i++)
            {
                SFX_Manager.Play("Powerup");
            }
            UnityEngine.Debug.Log("Awarded " + extras + " extra lives. Total lives: " + celestiaCount);
            progressAmount %= gemsForExtraLife;  // Remainder resets progress.
            progressSlider.value = progressAmount;

            if (celestiaText != null)
                celestiaText.text = " " + celestiaCount.ToString();
        }

        // Update the gem progress text to show the net total extra lives earned.
        if (gemProgressText != null)
        {
            int extraLivesFromGems = totalGemsCollected / gemsForExtraLife;
            gemProgressText.text = " " + extraLivesFromGems.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            isTouchingPortal = true;
            // Optionally, if you want to display the load canvas when at a portal and gems are 100 or more:
            if (progressAmount >= 100 && LoadCanvas != null)
            {
                LoadCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            isTouchingPortal = false;
            if (LoadCanvas != null)
            {
                LoadCanvas.SetActive(false);
            }
        }
    }
}
