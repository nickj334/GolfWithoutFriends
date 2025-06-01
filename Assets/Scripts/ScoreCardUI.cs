using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreCardUI : MonoBehaviour
{
    public List<TextMeshProUGUI> scoreTexts;  // Assign in inspector
    public int totalHoles = 4;  // Adjust as needed

    void Start()
    {
        // Initialize score placeholders to "-"
        for (int i = 0; i < totalHoles; i++)
        {
            scoreTexts[i].text = "-";
        }
    }

    public void UpdateScore(int holeNumber, int strokes)
    {
        if (holeNumber < 1 || holeNumber > totalHoles) return;

        // Update the specific hole with stroke count
        scoreTexts[holeNumber - 1].text = strokes.ToString();
    }
}
