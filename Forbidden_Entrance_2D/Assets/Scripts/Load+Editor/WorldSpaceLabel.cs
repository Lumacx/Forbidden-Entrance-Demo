using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceLabel : MonoBehaviour
{
    [Tooltip("The world object the label should follow.")]
    public Transform target;

    [Tooltip("Offset added to the target's position.")]
    public Vector3 offset;

    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the target world position plus the offset.
            Vector3 worldPosition = target.position + offset;
            // Convert that position to screen coordinates.
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);
            // Update the UI label's position.
            rectTransform.position = screenPoint;
        }
    }
}
