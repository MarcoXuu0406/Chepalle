using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoStart : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Livello0");
    }
}
