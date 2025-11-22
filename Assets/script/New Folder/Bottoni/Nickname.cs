using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NicknameMenu : MonoBehaviour
{
    public TMP_InputField nicknameField;
    public GameObject secondMenu;   // ← assegni il pannello SecondMenu nell’inspector

    public void OnConfirmPressed()
    {
        string nick = nicknameField.text;

        if (string.IsNullOrWhiteSpace(nick))
            nick = "Player";

        GameManager.Instance.StartRun(nick);

        SceneManager.LoadScene("Level0");
    }

    public void OnBackPressed()
    {
        gameObject.SetActive(false);   // chiude Nickname
        secondMenu.SetActive(true);    // torna al SecondMenu
    }
}
