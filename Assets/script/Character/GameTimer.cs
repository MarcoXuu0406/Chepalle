using UnityEngine;
using TMPro;

public class MagicTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float time;
    private float pulseSpeed = 2f;   // velocità pulsazione
    private float pulseScale = 0.05f; // intensità pulsazione

    void Update()
    {
        // TIMER MM:SS
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";

        // ANIMAZIONE MAGICA (pulsazione)
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseScale;
        timerText.transform.localScale = new Vector3(scale, scale, 1);
    }
}
