using UnityEngine;
using TMPro;

public class GhostFearHUD : MonoBehaviour
{
    public TextMeshProUGUI label;
    float until;
    bool on;

    void Update()
    {
        if (!on) return;
        float left = until - Time.time;
        if (left <= 0f)
        {
            on = false;
            if (label) label.gameObject.SetActive(false);
            return;
        }
        int s = (int)left;
        int cs = (int)((left - s) * 100f);
        if (label) label.text = $"SCARED: {s:00}:{cs:00}";
    }

    public void StartFear(float seconds)
    {
        on = seconds > 0f;
        until = Time.time + Mathf.Max(0f, seconds);
        if (label) label.gameObject.SetActive(on);
        if (on) Update();
    }

    public void StopFear()
    {
        on = false;
        if (label) label.gameObject.SetActive(false);
    }
}
