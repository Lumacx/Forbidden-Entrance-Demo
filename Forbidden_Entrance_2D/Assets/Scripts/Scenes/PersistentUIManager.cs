using UnityEngine;

public class PersistentUIManager : MonoBehaviour
{
    public static PersistentUIManager Instance { get; private set; }

    [Tooltip("Assign the canvas panel that you want to show/hide.")]
    public GameObject canvasPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this to show the panel.
    public void ShowPanel()
    {
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(true);
            Debug.Log("PersistentUIManager: Panel shown.");
        }
        else
        {
            Debug.LogError("PersistentUIManager: Canvas panel is not assigned!");
        }
    }

    // Call this to hide the panel.
    public void HidePanel()
    {
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(false);
            Debug.Log("PersistentUIManager: Panel hidden.");
        }
    }

    // Optionally, toggle the panel state.
    public void TogglePanel()
    {
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(!canvasPanel.activeSelf);
            Debug.Log("PersistentUIManager: Panel toggled. Now active: " + canvasPanel.activeSelf);
        }
    }
}
