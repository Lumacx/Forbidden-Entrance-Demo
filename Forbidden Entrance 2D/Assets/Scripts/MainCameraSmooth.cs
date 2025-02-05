using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The target to follow, usually your character.
    public Transform target;
    // Offset between the character and the camera.
    public Vector3 offset;
    // Smoothing factor for a smooth camera movement.
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
