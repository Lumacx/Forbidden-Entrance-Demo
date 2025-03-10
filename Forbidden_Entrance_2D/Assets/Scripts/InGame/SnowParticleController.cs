using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowParticleController : MonoBehaviour
{
    [Tooltip("The build index of the scene where snow should be active.")]
    public int snowActiveSceneIndex = 1; // e.g., Level 1 is build index 1

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
        // Enable snow only if the current scene's build index matches
        if (scene.buildIndex == snowActiveSceneIndex)
        {
            gameObject.SetActive(true);
            Debug.Log("Snow enabled for scene: " + scene.name);
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("Snow disabled for scene: " + scene.name);
        }

    }
}
