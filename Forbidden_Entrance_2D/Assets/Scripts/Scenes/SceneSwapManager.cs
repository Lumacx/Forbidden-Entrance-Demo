using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour
{
    public static SceneSwapManager instance;

    private static bool _loadFromDoor;

    private GameObject _player;
    private Collider2D _playercoll;
    private Collider2D _doorColl;
    private Vector3 _playerSpawnPosition;


    // Private field to store door target (for spawn point lookup in the new scene)
    //[SerializeField]
    private DoorTriggerInteraction.DoorToSpawnAt _doorToSpawnTo;

    [Header("Fade Settings")]
    public Animator whiteScreenAnimator;   // Animator that controls the white screen fade-out for scene transitions
    public float transitionTime = 1f;        // Time to wait after fade-out before loading the scene

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _player = GameObject.FindGameObjectWithTag("Player");
        _playercoll = _player.GetComponent<Collider2D>();

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Public method to swap scene. Called either from door interactions or from hold-to-load.
    /// </summary>
    /// <param name="myScene">The SceneField asset representing the scene to load.</param>
    /// <param name="doorToSpawnAt">The door target used for spawn lookup in the new scene.</param>

    public static void SwapSceneFromDoorUse(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt)
    {
        _loadFromDoor = true;
        instance.StartCoroutine(instance.FadeOutThenChangeScene(myScene, doorToSpawnAt));
    }

    private IEnumerator FadeOutThenChangeScene(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt = DoorTriggerInteraction.DoorToSpawnAt.None)
    {
        UserInput.DeactivatePlayerControls();

        // Trigger white screen fade-out animation
        //if (whiteScreenAnimator != null)
       // {
        //    whiteScreenAnimator.SetTrigger("Start");
        //    Debug.Log("White screen fade triggered.");
        //}
        //else
        //{
          //  Debug.LogWarning("White screen animator not assigned on SceneSwapManager.");
        //}

        // Wait for fade animation duration
        //yield return new WaitForSeconds(transitionTime);

        // Use the SceneFadeManager to start fade out.
        if (SceneFadeManager.instance != null)
        {
            SceneFadeManager.instance.StartFadeOut();
            // Wait until the fade-out is complete.
            while (SceneFadeManager.instance.IsFadingOut)
            {
                yield return null;
            }
        }
        else
        {
            Debug.LogWarning("SceneFadeManager instance not found; waiting fallback transitionTime.");
            yield return new WaitForSeconds(transitionTime);
        }

        _doorToSpawnTo = doorToSpawnAt;

        // Retrieve the scene name from the SceneField asset.
        string sceneToLoadName = myScene.SceneName;
        Debug.Log("Attempting to load scene: '" + sceneToLoadName + "'");
        if (string.IsNullOrEmpty(sceneToLoadName))
        {
            Debug.LogError("Scene name is empty. Ensure that the SceneField asset is assigned and its sceneName field is set.");
            yield break;
        }

        // Load the scene by name.
        SceneManager.LoadScene(sceneToLoadName);
    }

    //Called whenever a New Scene is Loaded (including the start of the game)
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)

    {
        // Start fade-in after the new scene loads.
        if (SceneFadeManager.instance != null)
            SceneFadeManager.instance.StartFadeIn();

        // Reset camera colliders.
        ResetCameraColliders();

        if (_loadFromDoor)
        {
            StartCoroutine(ActivatePlayerControlsAfterFadeIn());

            FindDoor(_doorToSpawnTo);
            _player.transform.position = _playerSpawnPosition;
            _loadFromDoor = false;
        }
        else
        {
            // Otherwise, default to the PlayerStart object in the scene.
            GameObject startPoint = GameObject.FindGameObjectWithTag("PlayerStart");
            if (startPoint != null)
            {
                _player.transform.position = startPoint.transform.position;
                Debug.Log("Player repositioned to PlayerStart: " + startPoint.transform.position);
            }
            else
            {
                Debug.LogWarning("No PlayerStart object found; player's position remains unchanged.");
            }
        }
        // Optionally, reactivate player controls.
        StartCoroutine(ActivatePlayerControlsAfterFadeIn());
    }

    private IEnumerator ActivatePlayerControlsAfterFadeIn()
    {
        while (SceneFadeManager.instance != null && SceneFadeManager.instance.IsFadingIn)
        {
            yield return null;
        }
        UserInput.ActivatePlayerControls();
    }

    private void FindDoor(DoorTriggerInteraction.DoorToSpawnAt doorSpawnNumber)
    {
        DoorTriggerInteraction[] doors = FindObjectsOfType<DoorTriggerInteraction>();

        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].CurrentDoorPosition == doorSpawnNumber)
            {
                _doorColl = doors[i].gameObject.GetComponent<Collider2D>();

                CalculateSpawnPosition();

                return;
            }
        }

    }

    private void CalculateSpawnPosition()
    {
        float colliderHeight = _playercoll.bounds.extents.y;
        _playerSpawnPosition = _doorColl.transform.position - new Vector3(0f, colliderHeight, 0f);

    }

    // Added ResetCameraColliders method to disable colliders on the main camera.
    private void ResetCameraColliders()
    {
        if (Camera.main == null)
        {
            Debug.LogWarning("No main camera found to reset colliders.");
            return;
        }
        Collider2D[] colliders = Camera.main.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
            Debug.Log("Disabled camera collider: " + col.name);
        }
    }

}

//remove to mix with HoldToload
//Original Video good for Metroidvanias https://www.youtube.com/watch?v=CQEqJ4TJzUk&list=PLfmYNuLHEy-PQ6j6kki9kmM3Z5CayRSI0&index=39

//public static void SwapSceneFromDoorUse(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt)
//{
//  instance.StartCoroutine(instance.FadeOutThenChangeScene(myScene, doorToSpawnAt));
//}

//private IEnumerator FadeOutThenChangeScene(SceneField myScene, DoorTriggerInteraction.DoorToSpawnAt doorToSpawnAt = DoorTriggerInteraction.DoorToSpawnAt.None)
//{
//   //start fading to black (Include Swai logo from other HoldToload script**)
//   SceneFadeManager.instance.StartFadeOut();

//   // Continue fading out as needed...
//   while (SceneFadeManager.instance.IsFadingOut)
//   {
//       yield return null;
//        }
//
//   _doorToSpawnTo = doorToSpawnAt;
//   SceneManager.LoadScene(myScene);


