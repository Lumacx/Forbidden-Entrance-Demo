using UnityEngine;
using UnityEngine.SceneManagement;

public class UICanvaStateManager : MonoBehaviour
{
    [Tooltip("Reference to the UI Canvas or parent GameObject you want to disable.")]
    public GameObject uiCanvas;

    [Tooltip("List of scene names in which the UI should be disabled.")]
    public string[] disableInScenes;

    private void Start()
    {
        // Immediately check the current scene in case we start there.
        CheckScene(SceneManager.GetActiveScene());
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
        CheckScene(scene);
    }

    private void CheckScene(Scene scene)
    {
        bool shouldDisable = false;
        foreach (var sceneName in disableInScenes)
        {
            if (scene.name.Equals(sceneName.Trim(), System.StringComparison.OrdinalIgnoreCase))
            {
                shouldDisable = true;
                break;
            }
        }

        if (uiCanvas != null)
        {
            uiCanvas.SetActive(!shouldDisable);
            UnityEngine.Debug.Log($"UIStateManager: UI Canvas '{uiCanvas.name}' active state set to {(!shouldDisable)} for scene {scene.name}");
        }
        else
        {
            UnityEngine.Debug.LogWarning("UIStateManager: uiCanvas reference is null!");
        }
    }
}