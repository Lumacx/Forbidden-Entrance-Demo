using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Cinemachine;
using Unity.Cinemachine;

public class CameraConfinerUpdater : MonoBehaviour
{
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
        // Optionally, you can also trigger fade-in here if needed:
        // SceneFadeManager.instance.StartFadeIn();

        // Start the coroutine to update the camera confiner after a short delay.
        StartCoroutine(UpdateCameraConfiner());
    }

    private IEnumerator UpdateCameraConfiner()
    {
        // Wait a brief moment to ensure that the new scene's objects are initialized.
        yield return new WaitForSeconds(0.1f);

        // Get the main camera's CinemachineConfiner2D component.
        CinemachineConfiner2D confiner = Camera.main.GetComponent<CinemachineConfiner2D>();
        if (confiner == null)
        {
            UnityEngine.Debug.LogWarning("No CinemachineConfiner2D component found on the main camera.");
            yield break;
        }

        // Look for the new level's camera confiner object by tag.
        GameObject confinerObject = GameObject.FindGameObjectWithTag("CameraConfiner");
        if (confinerObject == null)
        {
            UnityEngine.Debug.LogWarning("No object tagged 'CameraConfiner' found in the scene.");
            yield break;
        }

        // Get the Collider2D from the confiner object.
        Collider2D levelCollider = confinerObject.GetComponent<Collider2D>();
        if (levelCollider == null)
        {
            UnityEngine.Debug.LogWarning("The object tagged 'CameraConfiner' does not have a Collider2D component.");
            yield break;
        }

        UnityEngine.Debug.Log("Found level collider: " + levelCollider.name);
        // Assign the collider to the Cinemachine confiner.
        confiner.BoundingShape2D = levelCollider;
        // Force a recalculation of the bounding shape.
        confiner.InvalidateBoundingShapeCache();
        UnityEngine.Debug.Log("Cinemachine confiner updated with level collider: " + confinerObject.name);
    }
}
