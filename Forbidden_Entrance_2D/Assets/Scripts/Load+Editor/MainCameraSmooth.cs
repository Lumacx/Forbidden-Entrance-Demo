using System.Diagnostics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The target to follow (persistent player)
    public Vector3 offset;
    public float smoothTime = 0.3f;// Adjust this value for desired smoothness

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        // If target is not set in the Inspector, assign it from the persistent player.
        if (target == null && PersistentPlayer.Instance != null)
        {
            target = PersistentPlayer.Instance.transform;
            UnityEngine.Debug.Log("Camera target set to persistent player.");
        }
    }

    void LateUpdate()
    {
        // If target is still null, try to reassign it.
        if (target == null && PersistentPlayer.Instance != null)
        {
            target = PersistentPlayer.Instance.transform;
            UnityEngine.Debug.Log("LateUpdate: Camera target set to persistent player.");
        }

        if (target != null)
        {
            // Calculate desired position.
            Vector3 desiredPosition = target.position + offset;
            // Log for debugging:
            UnityEngine.Debug.Log($"Target position: {target.position}, Desired camera position: {desiredPosition}");

            // Smoothly move the camera towards the desired position.
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
            transform.position = smoothedPosition;
        }
        else
        {
            UnityEngine.Debug.LogWarning("CameraFollow: No target set.");
        }
    }
        //replace
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;


        /// <summary>
        /// Call this to reset the camera position/offset after loading a new scene.
        /// </summary>
      //  public void ResetCameraPosition()
      //  {
      //      // Option A: Move to a “CameraStart” object if it exists
      //      GameObject startObject = GameObject.FindGameObjectWithTag("CameraStart");
      //      if (startObject != null)
       //     {
       //         // Jump camera directly to this position
       //         transform.position = startObject.transform.position;
       //         UnityEngine.Debug.Log("Camera reset to CameraStart position: " + transform.position);
       //     }
       //     else
       //     {
       //         // Option B: Or just zero out the velocity and recalculate offset from the target
       //         velocity = Vector3.zero;
       //        if (target != null)
       //         {
       //             transform.position = target.position + offset;
       //         UnityEngine.Debug.Log("Camera reset to target+offset: " + transform.position);
       //         }
       //     }
       // }
}


