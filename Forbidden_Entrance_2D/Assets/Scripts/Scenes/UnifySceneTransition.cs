using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Diagnostics;
using System;
using System.ComponentModel;

public class UnifySceneTransition : MonoBehaviour
{
    [Header("Hold-To-Transition Settings")]
    public float holdDuration = 1.0f;          // How long to hold for transition
    public Image fillCircle;                   // UI Image for hold fill effect
    public Animator whiteScreenAnimation;      // Animator for white screen fade-out

    private float holdTimer = 0f;
    private bool isHolding = false;

    [Header("Progress Settings")]
    public Slider progressSlider;              // Slider showing collected progress
    private int progressAmount = 0;            // Current progress value
    private bool isTouchingPortal = false;     // Whether the player is touching a portal

    [Header("Scene Transition Settings")]
    public Animator transitionAnimator;        // (Optional) separate animator for scene transition
    public float transitionTime = 1f;          // Additional time to wait during scene transition

    [Header("Default Scene Settings")]
    public SceneField defaultSceneToLoad;

    public static UnifySceneTransition instance;

    //[SerializeField]
    private DoorTriggerInteraction.DoorToSpawnAt _doorToSpawnTo;
    
   // public void SetDoorTarget(DoorTriggerInteraction.DoorToSpawnAt target)
   // {
   //     _doorToSpawnTo = target;
   //     UnityEngine.Debug.Log("Unified transition door target set to: " + target);
   // }

    [Header("Load Canvas (Child of Player)")]
    public GameObject loadCanvas;              // UI canvas showing level load UI

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // Subscribe to gem collection events so that progress updates
        Gem.OnGemCollect += IncreaseProgressAmount;

        // Initialize progress slider if assigned
        if (progressSlider != null)
        {
            progressAmount = 0;
            progressSlider.value = progressAmount;
        }
    }
    //public static event Action OnHoldComplete;

    private void Update()
    {
        // Update hold timer and UI fill if holding
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            if (fillCircle != null)
                fillCircle.fillAmount = holdTimer / holdDuration;
                UnityEngine.Debug.Log("Hold timer: " + holdTimer);

            if (holdTimer >= holdDuration)
            {
                UnityEngine.Debug.Log("Hold complete, starting transition");
                // Trigger fade-out animation (white screen) **check animation with camera works
                if (whiteScreenAnimation != null)
                    whiteScreenAnimation.SetTrigger("Start");
                else
                    UnityEngine.Debug.LogWarning("White screen animation is not assigned!");

                // Ensure the persistent player is active and reset its scale
                gameObject.SetActive(true);
                if (PersistentPlayer.Instance != null)
                    PersistentPlayer.Instance.transform.localScale = PersistentPlayer.Instance.originalScale;
                else
                    UnityEngine.Debug.LogWarning("PersistentPlayer instance is missing!");

                // Use the default scene and current door target (which might be 'None')
                UnifySceneTransition.StartTransitionByName(defaultSceneToLoad, _doorToSpawnTo);

                ResetHold();
            }
        }
    }

    // Input callback to handle hold input (wire up via the new Input System)
    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
            UnityEngine.Debug.Log("Hold started");
            SFX_Manager.Play("Teleport_in");
        }
        else if (context.canceled)
        {
            UnityEngine.Debug.Log("Hold canceled");
            ResetHold();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0f;
        if (fillCircle != null)
            fillCircle.fillAmount = 0f;
    }

    // Call this method (or subscribe it to Gem.OnGemCollect) to increase progress.
    public void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        if (progressSlider != null)
            progressSlider.value = progressAmount;

        // If progress reaches 100 while touching a portal, activate the load canvas.
        if (progressAmount >= 100 && isTouchingPortal)
        {
            if (loadCanvas != null)
            {
                loadCanvas.SetActive(true);
                UnityEngine.Debug.Log("Level Complete: LoadCanvas activated.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            isTouchingPortal = true;
            if (progressAmount >= 100 && loadCanvas != null)
                loadCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            isTouchingPortal = false;
            if (loadCanvas != null)
                loadCanvas.SetActive(false);
        }
    }
        
    public static void StartTransitionByName(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt)
    {
        instance.StartCoroutine(instance.FadeOutThenChangeScene(myScene, doorToSpawnAt));
    }

    private IEnumerator FadeOutThenChangeScene(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt = DoorTriggerInteraction.DoorToSpawnAt.None)
    {
        yield return new WaitForSeconds(transitionTime);

         _doorToSpawnTo = doorToSpawnAt;

        // Debug the scene name
        string sceneToLoadName = myScene.SceneName;
        UnityEngine.Debug.Log("Loading scene: " + sceneToLoadName);

        if (string.IsNullOrEmpty(sceneToLoadName))
        {
            UnityEngine.Debug.LogError("Scene name is empty. Ensure that the SceneField asset is assigned and its _sceneName field is set.");
            yield break;
        }

        SceneManager.LoadScene(myScene);
        
        {
            yield return null;
        }
        
        UpdateSpawnPointAndCamera();
    }

    private void UpdateSpawnPointAndCamera()
    {
        // Determine the spawn point:
        // If a door target is specified, try to find a spawn point named "DoorSpawn_{doorTarget}"
        GameObject spawnPoint = null;
        if (_doorToSpawnTo != DoorTriggerInteraction.DoorToSpawnAt.None)
        {
        // For example, if doorTarget is Door1, the spawn point GameObject in the scene should be named "DoorSpawn_Door1".
            string spawnPointName = "DoorSpawn_" + _doorToSpawnTo.ToString();
            spawnPoint = GameObject.Find(spawnPointName);
        }
        // If not found or no door target specified, use default spawn point (tagged "PlayerStart")
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("PlayerStart");
        }

        if (spawnPoint != null && PersistentPlayer.Instance != null)
        {

            UnityEngine.Debug.Log("Spawn point found: " + spawnPoint.name);
            PersistentPlayer.Instance.transform.position = spawnPoint.transform.position;
            PersistentPlayer.Instance.transform.localScale = PersistentPlayer.Instance.originalScale;
            UnityEngine.Debug.Log("Player moved to spawn point: " + spawnPoint.transform.position);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Spawn point not found or persistent player missing.");
        }

            CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
            if (camFollow != null && PersistentPlayer.Instance != null)
            {
                camFollow.target = PersistentPlayer.Instance.transform;
            UnityEngine.Debug.Log("Main camera tracking updated to persistent player.");
            }
        
    }
}
