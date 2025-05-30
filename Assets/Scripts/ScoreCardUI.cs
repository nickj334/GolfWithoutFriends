using UnityEngine;
using TMPro;

public class ScoreCardUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if (GameManager.Instance == null) return;

        string display = "Score Card:\n";
        for (int i = 1; i <= 3; i++)
        {
            int strokes = GameManager.Instance.GetScore(i);
            display += $"Hole {i}: {strokes}\n";
        }

        scoreText.text = display;
    }
}
