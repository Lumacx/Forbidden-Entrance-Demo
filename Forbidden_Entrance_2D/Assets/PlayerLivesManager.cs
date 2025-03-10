using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLivesManager : MonoBehaviour
{
    [Header("Lives Settings")]
    public int startingLives = 3;
    private int currentLives;

    [Header("Gem Conversion Settings")]
    public int gemsForExtraLife = 100;      // Gems needed to earn an extra life
    private int currentGemProgress = 0;     // Gems collected since last extra life

    [Header("UI References")]
    public TMP_Text livesText;              // UI text for displaying current lives
    public TMP_Text gemProgressText;        // (Optional) UI text for detail showing gem progress
    public GameObject gameOverCanvas;       // Game Over canvas (set inactive in Inspector)

    private void Start()
    {
        currentLives = startingLives;
        UpdateLivesUI();
        UpdateGemProgressUI();

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);

        // Subscribe to gem collection events.
        Gem.OnGemCollect += OnGemCollected;
    }

    private void OnDestroy()
    {
        Gem.OnGemCollect -= OnGemCollected;
    }

    // This method is called whenever a gem is collected.
    void OnGemCollected(int amount)
    {
        currentGemProgress += amount;
        // For each complete gemsForExtraLife (e.g., 100) gems, award an extra life.
        while (currentGemProgress >= gemsForExtraLife)
        {
            currentGemProgress -= gemsForExtraLife;
            AddLife(1);
            SFX_Manager.Play("Powerup"); // Play sound each extra life awarded.
        }
        UpdateGemProgressUI();
    }

    /// <summary>
    /// Adds extra lives.
    /// </summary>
    public void AddLife(int amount)
    {
        currentLives += amount;
        UnityEngine.Debug.Log("Added " + amount + " life. Total lives: " + currentLives);
        UpdateLivesUI();
    }

    /// <summary>
    /// Call this method to subtract one life when the player dies.
    /// </summary>
    public void DeductLife()
    {
        currentLives--;
        UnityEngine.Debug.Log("Life deducted. Lives remaining: " + currentLives);
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            TriggerGameOver();
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = " " + currentLives;
    }

    private void UpdateGemProgressUI()
    {
        if (gemProgressText != null)
        {
            int extraLivesFromGems = (startingLives - currentLives + (totalExtraLivesAwarded()));
            // Alternatively, you can display totalGemCollected / gemsForExtraLife:
            int netExtraLives = (currentGemProgress + gemsForExtraLife * ((startingLives - currentLives) / gemsForExtraLife)) / gemsForExtraLife;
            // For simplicity, we'll show:
            gemProgressText.text = "Minting Progress % "; //+ ((totalGemCollected()) / gemsForExtraLife).ToString();
        }
    }

    // (Optional helper methods if needed. For now, we use totalGemCollected.)
    private int totalGemCollected()
    {
        // Return the total gems collected if you're tracking that.
        // In our OnGemCollected, we accumulate currentGemProgress, so you might need a separate variable.
        return currentGemProgress; // Replace with your actual total if needed.
    }

    private int totalExtraLivesAwarded()
    {
        // Calculate how many extra lives have been awarded. 
        // You might need to track that separately if you want to display it.
        return (startingLives - currentLives);
    }

    /// <summary>
    /// Called when lives reach zero.
    /// </summary>
    private void TriggerGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            // Optionally pause the game.
            Time.timeScale = 0f;
            UnityEngine.Debug.Log("Game Over triggered.");
        }
        else
        {
            UnityEngine.Debug.LogError("GameOverCanvas is not assigned in PlayerLivesManager!");
        }
    }

    /// <summary>
    /// This method can be linked to a UI button to restart the current level.
    /// It resets lives and gem progress, hides the Game Over UI, resets time scale, and reloads the current scene.
    /// </summary>
    public void RestartLevel()
    {
        // Reset the game time.
        Time.timeScale = 1f;
        // Reset lives and gem progress.
        currentLives = startingLives;
        currentGemProgress = 0;
        UpdateLivesUI();
        UpdateGemProgressUI();
        // Hide Game Over canvas.
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);
        // Reload the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
