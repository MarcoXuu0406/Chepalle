using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject targetPanel;

    public void OnBackPressed()
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (targetPanel != null)
            targetPanel.SetActive(true);
    }
}
