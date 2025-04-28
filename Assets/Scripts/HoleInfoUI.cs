using UnityEngine;
using TMPro;

public class HoleInfoUI : MonoBehaviour
{
    public TMP_Text holeNumberText;
    public TMP_Text parText;
    public TMP_Text shotCountText;

    private int currentHole = 1;  // Example: Hole 1
    private int par = 3;          // Example: Par 3
    private int shotCount = 0;    // How many shots

    void Start()
    {
        shotCount = 0;
        UpdateHoleInfoDisplay();
    }

    // shout counter
    public void IncrementShot()
    {
        shotCount++;
        UpdateHoleInfoDisplay();
    }

    // reset after ball is in the cup
    public void ResetShots()
    {
        shotCount = 0;
        UpdateHoleInfoDisplay();
    }

    // updating UI display
    private void UpdateHoleInfoDisplay()
    {
        holeNumberText.text = "Hole " + currentHole;
        parText.text = "Par " + par;
        shotCountText.text = "Shots: " + shotCount;
    }
}
