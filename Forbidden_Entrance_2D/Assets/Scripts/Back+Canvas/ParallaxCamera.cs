using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;

    private float oldPosition;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        oldPosition = transform.position.x;
    }
    void LateUpdate()
    {
        if (transform.position.x != oldPosition)
        {
            float delta = oldPosition - transform.position.x;
            onCameraTranslate?.Invoke(delta);
            oldPosition = transform.position.x;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        oldPosition = transform.position.x;
    }

    //Replace by LateUpdate
    //void Update()
    // {
    //     if (transform.position.x != oldPosition)
    //     {
    //         if (onCameraTranslate != null)
    //         {
    //             float delta = oldPosition - transform.position.x;
    //             onCameraTranslate(delta);
    //         }

    //         oldPosition = transform.position.x;
    //     }
    // }
}