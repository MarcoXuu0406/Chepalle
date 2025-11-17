using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float time;

    void Update()
    {
        time += Time.deltaTime;
        timerText.text = time.ToString("F1") + "s";
    }
}
