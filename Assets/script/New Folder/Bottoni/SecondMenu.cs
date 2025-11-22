using UnityEngine;

public class SecondMenu : MonoBehaviour
{
    public GameObject secondMenu;           // Il pannello SecondMenu
    public GameObject nicknamePanel;        // Pannello Nickname
    public GameObject leaderboardCompleted; // Pannello LeaderBoard
    public GameObject leaderboardFailed;    // Pannello NoLeaderBoard
    public GameObject homeMenu;             // Pannello HomeMenu

    public void OnInizioPressed()
    {
        secondMenu.SetActive(false);
        nicknamePanel.SetActive(true);
    }

    public void OnLeaderboardPressed()
    {
        secondMenu.SetActive(false);
        leaderboardCompleted.SetActive(true);
    }

    public void OnNoLeaderboardPressed()
    {
        secondMenu.SetActive(false);
        leaderboardFailed.SetActive(true);
    }

    public void OnBackPressed()
    {
        secondMenu.SetActive(false);
        homeMenu.SetActive(true);
    }
}
