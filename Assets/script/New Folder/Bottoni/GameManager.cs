using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName = "";
    public float timer = 0f;
    public bool timerRunning = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (timerRunning)
            timer += Time.deltaTime;
    }

    public void StartRun(string nickname)
    {
        playerName = nickname;
        timer = 0f;
        timerRunning = true;
    }
}
