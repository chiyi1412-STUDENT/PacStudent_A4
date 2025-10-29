using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float t;

    void Update()
    {
        t += Time.deltaTime;
        int m = (int)(t / 60f);
        int s = (int)(t % 60f);
        int cs = (int)((t - Mathf.Floor(t)) * 100f);
        if (timerText != null) timerText.text = $"{m:00}:{s:00}:{cs:00}";
    }
}
