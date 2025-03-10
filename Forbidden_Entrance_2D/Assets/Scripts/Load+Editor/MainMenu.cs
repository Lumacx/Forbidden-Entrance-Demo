using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Playgame()
    {
        // Check if a persistent player exists (active session)
        if (PersistentPlayer.Instance != null)
        {
            int levelToLoad = 1;  // Default to level 1
                                  // Check if we have stored a last level index
            if (PlayerPrefs.HasKey("LastLevel"))
            {
                levelToLoad = PlayerPrefs.GetInt("LastLevel");
                Debug.Log("Active session found, loading last level: " + levelToLoad);
            }
            else
            {
                Debug.Log("Active session found, but no last level stored. Defaulting to level 1.");
            }
            // Load the level asynchronously for active sessions
            SceneManager.LoadSceneAsync(levelToLoad);
        }
        else
        {
            Debug.Log("No active session, loading level 1 by name.");
            // For first time launch, load the scene by name
            SceneManager.LoadScene("1 Level - Snow 1.0");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
