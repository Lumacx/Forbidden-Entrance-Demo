using UnityEngine;

public class HighlightInteraction : MonoBehaviour
{
    // Reference to the main SpriteRenderer (optional if you want to enforce red)
    private SpriteRenderer spriteRenderer;

    // The desired normal color for the item (red)
    [SerializeField] private Color normalColor = Color.white;

    // Child GameObject that acts as the border (set in Inspector)
    [SerializeField] private GameObject border;

    void Awake()
    {
        // Get the main sprite renderer and enforce the red color
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = normalColor;
        }

        // Ensure the border is off by default
        if (border != null)
        {
            border.SetActive(false);
        }
    }

    // When the player enters the item's trigger area, enable the border.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (border != null)
            {
                border.SetActive(true);
            }
        }
    }

    // When the player exits, disable the border.
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (border != null)
            {
                border.SetActive(false);
            }
        }
    }
}
