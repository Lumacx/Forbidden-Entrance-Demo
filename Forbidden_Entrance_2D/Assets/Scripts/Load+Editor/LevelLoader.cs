using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Cinemachine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
        // Modify for checkpoint instead of just mouse click as needed
        if (Input.GetMouseButtonDown(2))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play transition animation
        transition.SetTrigger("Start");

        // Wait for the transition animation to finish
        yield return new WaitForSeconds(transitionTime);

        // Load the new scene asynchronously
        AsyncOperation op = SceneManager.LoadSceneAsync(levelIndex);
        while (!op.isDone)
        {
            yield return null;
        }

        // After the new scene has loaded, update spawn point, scale, and camera tracking
        UpdateSpawnPointAndCamera();
    }

    void UpdateSpawnPointAndCamera()
    {
        // Find the spawn point in the new scene using the tag "PlayerStart"
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("PlayerStart");
        if (spawnPoint != null && PersistentPlayer.Instance != null)
        {
            // Move the persistent player to the spawn point
            PersistentPlayer.Instance.transform.position = spawnPoint.transform.position;
            // Reset player's scale to the original scale
            PersistentPlayer.Instance.transform.localScale = PersistentPlayer.Instance.originalScale;
            Debug.Log("Player moved to spawn point with original scale: " + PersistentPlayer.Instance.originalScale);
        }
        else
        {
            Debug.LogWarning("Spawn point not found or PersistentPlayer instance missing.");
        }

        // Option 1: Update Cinemachine Virtual Camera if available
        // CinemachineVirtualCamera vcam = FindObjectOfType<CinemachineVirtualCamera>();
        // if (vcam != null && PersistentPlayer.Instance != null)
        // {
        //     vcam.Follow = PersistentPlayer.Instance.transform;
        //     vcam.LookAt = PersistentPlayer.Instance.transform;
        //     UnityEngine.Debug.Log("Cinemachine camera target updated.");
        // }

        // Option 2: Update main camera's tracking if using a custom CameraFollow script
        // Optionally update a custom CameraFollow script on the main camera if used
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null && PersistentPlayer.Instance != null)
        {
            cameraFollow.target = PersistentPlayer.Instance.transform;
            Debug.Log("Main camera tracking updated to persistent player.");
        }
    }
}