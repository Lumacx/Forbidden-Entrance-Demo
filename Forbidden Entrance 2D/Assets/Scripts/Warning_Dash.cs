using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Warning_Dash : MonoBehaviour
{
    // Reference to the TMP Text element (assign in Inspector)
    public TMP_Text warningText;

    // Duration for how long the warning is visible
    public float warningDuration = 2f;

    private void Start()
    {
        // Ensure the warning is initially hidden
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowWarning("Warning: Use E to Dash!");
        }
    }

    // Optional: Hide the warning when the player leaves the trigger area
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (warningText != null)
            {
                warningText.gameObject.SetActive(false);
            }
        }
    }

    // Display the warning message for a set duration
    void ShowWarning(string message)
    {
        if (warningText != null)
        {
            warningText.text = message;
            warningText.gameObject.SetActive(true);
            // Optionally, start a coroutine to hide it after a few seconds
            StartCoroutine(HideWarningAfterDelay(warningDuration));
        }
    }

    IEnumerator HideWarningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }
}
