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

        // Just set both off at start
        if (helpCanvas_Practice != null) helpCanvas_Practice.SetActive(false);
        if (helpCanvas_GameMode != null) helpCanvas_GameMode.SetActive(false);

        // Now activate the correct one
        if (isPracticeMode && helpCanvas_Practice != null)
            helpCanvas_Practice.SetActive(true);
        else if (!isPracticeMode && helpCanvas_GameMode != null)
            helpCanvas_GameMode.SetActive(true);

        Time.timeScale = 0f;
        if (golfBallAudio != null) golfBallAudio.enabled = false;
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
