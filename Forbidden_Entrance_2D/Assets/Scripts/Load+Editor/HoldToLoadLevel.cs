using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class HoldToLoadLevel : MonoBehaviour
{
    [Header("Hold-To-Transition Settings")]
    public float holdDuration = 1.0f;          // Duration required to hold Q
    public UnityEngine.UI.Image fillCircle;                   // UI Image to display the fill progress
    public Animator whiteScreenAnimation;      // (Optional) white screen animation on the player side

    //newly add to mix with SceneSwapManager
    [Header("Default Scene Settings")]
    public SceneField defaultSceneToLoad;      // Default scene asset to load when holding Q
    public DoorTriggerInteraction.DoorToSpawnAt defaultDoorTarget = DoorTriggerInteraction.DoorToSpawnAt.None;
    //end

    private float holdTimer = 0f;
    private bool isHolding = false;

    //public static event Action OnHoldComplete; //removed on the mix

    void Update()
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            if (fillCircle != null)
                fillCircle.fillAmount = holdTimer / holdDuration;
            // When hold duration is reached, trigger transition.
            if (holdTimer >= holdDuration)
            {
                UnityEngine.Debug.Log("Hold complete, initiating scene swap.");

                // Optionally trigger a white screen fade on this side.
                if (whiteScreenAnimation != null)
                    whiteScreenAnimation.SetTrigger("Start");

                // Ensure the persistent player is active and reset scale.
                if (PersistentPlayer.Instance != null)
                {
                    PersistentPlayer.Instance.gameObject.SetActive(true);
                    PersistentPlayer.Instance.transform.localScale = PersistentPlayer.Instance.originalScale;
                }

                // Call the global SceneSwapManager to swap scene using the default scene and door target.
                if (SceneSwapManager.instance != null)
                    //SceneSwapManager.instance.SwapSceneFromDoorUse(defaultSceneToLoad, defaultDoorTarget);
                     SceneSwapManager.SwapSceneFromDoorUse(defaultSceneToLoad, defaultDoorTarget);
                else
                    UnityEngine.Debug.LogError("SceneSwapManager instance not found.");
                
                    // Resetting scale to Vector3.one (modify if your original scale is different)
                //    PersistentPlayer.Instance.transform.localScale = Vector3.one;
                //}

                // Trigger level load
                //OnHoldComplete?.Invoke();

                ResetHold();
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
            UnityEngine.Debug.Log("Hold started.");
            SFX_Manager.Play("Teleport_in");
        }
        else if (context.canceled)
        {
            UnityEngine.Debug.Log("Hold canceled.");
            ResetHold();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0;
        if (fillCircle != null)
            fillCircle.fillAmount = 0f;
    }
}
