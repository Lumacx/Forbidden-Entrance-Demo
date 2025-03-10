using UnityEngine;

public class PersistentPlayer : MonoBehaviour
{
    public static PersistentPlayer Instance;
    public Vector3 originalScale;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Store the original scale
            originalScale = transform.localScale;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
