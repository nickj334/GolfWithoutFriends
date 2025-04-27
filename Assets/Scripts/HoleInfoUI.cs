using UnityEngine;
using TMPro;  // << Don't forget this!

public class HoleInfoUI : MonoBehaviour
{
    public TMP_Text holeNumberText;
    public TMP_Text parText;
    public TMP_Text shotCountText;

    public void UpdateHoleInfo(int holeNumber, int par, int shots)
    {
        holeNumberText.text = "Hole " + holeNumber;
        parText.text = "Par " + par;
        shotCountText.text = "Shots: " + shots;
    }
}
