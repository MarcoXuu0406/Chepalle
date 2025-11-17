using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
  public void OpenLevel(int levelId){
    
    string livelloNome = "Level" + levelId;
    SceneManager.LoadScene(livelloNome);
  }
}
