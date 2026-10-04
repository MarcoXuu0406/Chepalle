using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject secondMenu;

    public void OnStartPressed()
    {
        homeMenu.SetActive(false);
        secondMenu.SetActive(true);
    }

    public void OnQuitPressed()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
