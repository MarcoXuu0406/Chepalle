using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public Transform player;
    public Transform levelEnd;
    public Image progressFill;

    float startX;

    void Start()
    {
        startX = player.position.x;
    }

    void Update()
    {
        float distance = levelEnd.position.x - startX;
        float current = player.position.x - startX;

        float progress = Mathf.Clamp01(current / distance);
        progressFill.fillAmount = progress;
    }
}
