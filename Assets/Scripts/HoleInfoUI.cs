using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HoleInfoUI : MonoBehaviour
{
    public TMP_Text holeNumberText;
    public TMP_Text parText;
    public TMP_Text shotCountText;

    private string holeName = "Hole 1"; // setting base hole name
    private int par = 3;          // Example: Par 3
    private int shotCount = 0;    // How many shots
    private Dictionary<string, (string holeName, int par)> holeData = new Dictionary<string, (string, int)>
    {
        {"Hub", ("Hole 1", 3) },
        {"Hole1", ("Hole 2", 4) },
        {"Hole2", ("Hole 3", 4) },
        {"Hole3", ("Hole 4", 7) }
    };


    void Start()
    {
        // Auto-assign TextMeshProUGUI references if missing
        if (holeNumberText == null)
            holeNumberText = GameObject.Find("HoleNumberText")?.GetComponent<TMP_Text>();

        if (parText == null)
            parText = GameObject.Find("ParText")?.GetComponent<TMP_Text>();

        if (shotCountText == null)
            shotCountText = GameObject.Find("ShotCountText")?.GetComponent<TMP_Text>();

        shotCount = 0;
        UpdateHoleInfo();
        UpdateHoleInfoDisplay();
    }

    public void IncrementShot()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterShot();  // Use central tracking
        }
        UpdateHoleInfoDisplay();
    }

    // reset after ball is in the cup
    public void ResetShots()
    {
        shotCount = 0;
        UpdateHoleInfoDisplay();
    }

    private void UpdateHoleInfo()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (holeData.ContainsKey(sceneName))
        {
            holeName = holeData[sceneName].holeName;
            par = holeData[sceneName].par;
        }
        else
        {
            holeName = "Unknown Hole";
            par = 3;
        }
    }

    // updating UI display
    public void UpdateHoleInfoDisplay()
    {
        int strokes = GameManager.Instance.GetScore(GameManager.Instance.currentHoleIndex);
        holeNumberText.text = holeName;
        parText.text = "Par " + par;
        shotCountText.text = "Shots: " + strokes;
    }




}
