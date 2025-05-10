using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject helpCanvas;
    private GolfBallController golfBallScript;
    private HoleInfoUI holeInfoScript;

    void Start() {
        golfBallScript = GameObject.Find("GolfBall").GetComponent<GolfBallController>();
        holeInfoScript = GameObject.Find("HoleInfoUIManager").GetComponent<HoleInfoUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            helpCanvas.SetActive(!helpCanvas.activeSelf);
        }
    }

    public void StartPracticeHole()
    {
        helpCanvas.SetActive(false);
    }

    public void LoadHole1()
    {
        SceneManager.LoadScene("Hole1");
    }

    public void ResetScene() {
        golfBallScript.ResetBall();
        holeInfoScript.ResetShots();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
