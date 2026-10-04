using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealtUI : MonoBehaviour
{
    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void UpdateHearts(int current, int max)
    {
        Debug.Log("UI aggiornata → Cuori: " + current + "/" + max);

        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < current)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
