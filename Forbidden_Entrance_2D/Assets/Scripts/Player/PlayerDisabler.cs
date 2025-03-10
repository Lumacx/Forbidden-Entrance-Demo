using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDisabler : MonoBehaviour
{
    [Tooltip("Disable the player if the active scene name matches this value. Leave empty to use build index.")]
    public string sceneNameToDisable;

    [Tooltip("Disable the player if the active scene build index matches this value (if Scene Name is empty).")]
    public int sceneIndexToDisable = 0; // Set to 0 if Main Menu is scene 0

    private void Awake()
    {
        // Check immediately on Awake in case this is the starting scene.
        CheckSceneAndSetActive(SceneManager.GetActiveScene());
    }

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
        CheckSceneAndSetActive(scene);
    }

    private void CheckSceneAndSetActive(Scene scene)
    {
        bool shouldDisable = false;

        if (!string.IsNullOrEmpty(sceneNameToDisable))
        {
            // Compare scene names (case-insensitive)
            shouldDisable = scene.name.Equals(sceneNameToDisable, System.StringComparison.OrdinalIgnoreCase);
        }
        else if (sceneIndexToDisable >= 0)
        {
            shouldDisable = (scene.buildIndex == sceneIndexToDisable);
        }

        // Disable player if the condition is met.
        gameObject.SetActive(!shouldDisable);
        UnityEngine.Debug.Log($"PlayerDisabler: {gameObject.name} active state set to {!shouldDisable} for scene {scene.name}");
    }
}
