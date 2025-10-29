using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime;
    private bool running = true;

    void Update()
    {
        if (!running) return;

        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);

        if (timerText != null)
            timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
    }

    public void StopTimer()
    {
        running = false;
    }

    public void StartTimer()
    {
        running = true;
    }

    public float GetTime()
    {
        return elapsedTime;
    }
}
