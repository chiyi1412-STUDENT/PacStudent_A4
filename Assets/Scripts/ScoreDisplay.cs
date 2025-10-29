using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        UpdateView();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateView();
    }

    public void SetScore(int value)
    {
        score = value;
        UpdateView();
    }

    void UpdateView()
    {
        if (scoreText != null) scoreText.text = $"SCORE: {score:000000}";
    }
}
