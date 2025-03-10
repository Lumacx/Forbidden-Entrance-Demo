using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDisabler : MonoBehaviour
{
    [Tooltip("Disable this UI Canvas if the active scene name matches this value. Leave empty to use build index.")]
    public string sceneNameToDisable;

    [Tooltip("Disable this UI Canvas if the active scene build index matches this value (if Scene Name is empty).")]
    public int sceneIndexToDisable = -1;

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
        bool disable = false;
        if (!string.IsNullOrEmpty(sceneNameToDisable))
        {
            disable = scene.name.Equals(sceneNameToDisable, System.StringComparison.OrdinalIgnoreCase);
        }
        else if (sceneIndexToDisable >= 0)
        {
            disable = scene.buildIndex == sceneIndexToDisable;
        }

        gameObject.SetActive(!disable);
        Debug.Log("UIDisabler: " + gameObject.name + " active state set to " + (!disable) + " for scene " + scene.name);
    }
}
