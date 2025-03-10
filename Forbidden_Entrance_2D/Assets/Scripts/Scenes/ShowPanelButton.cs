using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    // This method can be assigned to the button's OnClick event.
    public void OnButtonClicked()
    {
        if (PersistentUIManager.Instance != null)
        {
            // Here you can choose to call ShowPanel(), HidePanel(), or TogglePanel().
            PersistentUIManager.Instance.TogglePanel();
        }
        else
        {
            Debug.LogError("PersistentUIManager instance not found!");
        }
    }
}
