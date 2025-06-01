using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject helpCanvas_Practice;
    public GameObject helpCanvas_GameMode;
    private GolfBallController golfBallScript;
    private HoleInfoUI holeInfoScript;
    private AudioSource golfBallAudio;
    private bool isPracticeMode;

    void Start()
    {
        isPracticeMode = GameModeManager.Instance.IsPracticeMode;

        golfBallScript = GameObject.Find("GolfBall")?.GetComponent<GolfBallController>();
        holeInfoScript = GameObject.Find("HoleInfoUIManager")?.GetComponent<HoleInfoUI>();
        golfBallAudio = GameObject.Find("GolfBall")?.GetComponent<AudioSource>();

        // Start both canvases disabled
        if (helpCanvas_Practice != null) helpCanvas_Practice.SetActive(false);
        if (helpCanvas_GameMode != null) helpCanvas_GameMode.SetActive(false);

        if (isPracticeMode)
        {
            // Practice Mode: Show Practice Menu on scene load
            if (helpCanvas_Practice != null) helpCanvas_Practice.SetActive(true);
            Time.timeScale = 0f;
            if (golfBallAudio != null) golfBallAudio.enabled = false;
        }
        else
        {
            // Game Mode: Everything stays hidden and running
            Time.timeScale = 1f;
            if (golfBallAudio != null) golfBallAudio.enabled = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPracticeMode)
                ToggleMenu(helpCanvas_Practice);
            else
                ToggleMenu(helpCanvas_GameMode);
        }
    }

    void ToggleMenu(GameObject menu)
    {
        if (menu == null) return;

        bool isActive = !menu.activeSelf;
        menu.SetActive(isActive);

        Time.timeScale = isActive ? 0f : 1f;
        if (golfBallAudio != null)
            golfBallAudio.enabled = !isActive;
    }

    public void StartPracticeHole()
    {
        SceneManager.LoadScene("Hub");
    }

    public void LoadHole1()
    {
        Debug.Log("Hole1 button clicked");
        SceneManager.LoadScene("Hole1");
    }

    public void LoadHole2()
    {
        Debug.Log("Hole2 button clicked");
        SceneManager.LoadScene("Hole2");
    }

    public void LoadHole3()
    {
        Debug.Log("Hole3 button clicked");
        SceneManager.LoadScene("Hole3");
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
