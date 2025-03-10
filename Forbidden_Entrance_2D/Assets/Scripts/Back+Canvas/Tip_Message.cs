using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tip_MomMessage : MonoBehaviour
{
    // Reference to the Image element (assign in Inspector)
    public Image warningImage;

    // Duration (in seconds) the image will remain visible
    public float displayDuration = 4f;

    private void Start()
    {
        // Ensure the warning image is hidden at the start
        if (warningImage != null)
        {
            warningImage.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowWarning();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Optionally hide the warning immediately when the player leaves the trigger.
        if (collision.CompareTag("Player") && warningImage != null)
        {
            warningImage.gameObject.SetActive(false);
        }
    }

    private void ShowWarning()
    {
        if (warningImage != null)
        {
            warningImage.gameObject.SetActive(true);
            StartCoroutine(HideWarningAfterDelay(displayDuration));
        }
    }

    private IEnumerator HideWarningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (warningImage != null)
        {
            warningImage.gameObject.SetActive(false);
        }
    }
}
