using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActivator : MonoBehaviour
{
    [Tooltip("The build index of the scene where the player should be active.")]
    public int activateSceneIndex = 1; // Set this to your Level 1's build index

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == activateSceneIndex)
        {
            ActivatePlayer();
        }
    }

    private void ActivatePlayer()
    {
        if (PersistentPlayer.Instance != null)
        {
            PersistentPlayer.Instance.gameObject.SetActive(true);
            UnityEngine.Debug.Log("Player activated in scene: " + SceneManager.GetActiveScene().name);
        }
        else
        {
            UnityEngine.Debug.LogWarning("No PersistentPlayer instance found.");
        }
    }
}
