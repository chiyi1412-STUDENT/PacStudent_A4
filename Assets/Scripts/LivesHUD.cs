using UnityEngine;
using UnityEngine.UI;

public class LivesHUD : MonoBehaviour
{
    public Image life1;
    public Image life2;
    public Image life3;
    public int lives = 3;

    void Start()
    {
        UpdateView();
    }

    public void SetLives(int value)
    {
        lives = Mathf.Clamp(value, 0, 3);
        UpdateView();
    }

    public void LoseOne()
    {
        SetLives(lives - 1);
    }

    void UpdateView()
    {
        if (life1) life1.enabled = lives >= 1;
        if (life2) life2.enabled = lives >= 2;
        if (life3) life3.enabled = lives >= 3;
    }
}
