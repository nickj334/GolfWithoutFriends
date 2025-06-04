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

    public static class PracticeState
    {
        public static bool suppressAutoMenu = false;
    }

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
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Hub" && !PracticeState.suppressAutoMenu)
            {
                helpCanvas_Practice?.SetActive(true);
                Time.timeScale = 0f;
                if (golfBallAudio != null) golfBallAudio.enabled = false;
            }
            else
            {
                helpCanvas_Practice?.SetActive(false);
                Time.timeScale = 1f;
                if (golfBallAudio != null) golfBallAudio.enabled = true;
            }

            PracticeState.suppressAutoMenu = false;
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
        if (isPracticeMode)
        {
            PracticeState.suppressAutoMenu = true;
            helpCanvas_Practice?.SetActive(false);
            Time.timeScale = 1f;
            if (golfBallAudio != null) golfBallAudio.enabled = true;
        }

        SceneManager.LoadScene("Hub");
    }

    public void LoadHole1()
    {
        if (isPracticeMode)
        {
            PracticeState.suppressAutoMenu = true;
            helpCanvas_Practice?.SetActive(false);
            Time.timeScale = 1f;
            if (golfBallAudio != null) golfBallAudio.enabled = true;
        }

        SceneManager.LoadScene("Hole1"); // Use "Hub" here if Hole1 is the Hub scene
    }

    public void LoadHole2()
    {
        if (isPracticeMode)
        {
            PracticeState.suppressAutoMenu = true;
            helpCanvas_Practice?.SetActive(false);
            Time.timeScale = 1f;
            if (golfBallAudio != null) golfBallAudio.enabled = true;
        }

        SceneManager.LoadScene("Hole2");
    }

    public void LoadHole3()
    {
        if (isPracticeMode)
        {
            PracticeState.suppressAutoMenu = true;
            helpCanvas_Practice?.SetActive(false);
            Time.timeScale = 1f;
            if (golfBallAudio != null) golfBallAudio.enabled = true;
        }

        SceneManager.LoadScene("Hole3");
    }

    public void ResetScene()
    {
        golfBallScript.ResetBall();
        holeInfoScript.ResetShots();
    }

    public void ResumeGame()
    {
        if (!isPracticeMode && helpCanvas_GameMode != null)
        {
            helpCanvas_GameMode.SetActive(false);
            Time.timeScale = 1f;
            if (golfBallAudio != null) golfBallAudio.enabled = true;
        }
    }

    public void ResetCurrentHole()
    {
        if (GameManager.Instance != null)
        {
            int index = GameManager.Instance.currentHoleIndex;

            // Reset stored stroke count
            if (GameManager.Instance.holeScores.ContainsKey(index))
                GameManager.Instance.holeScores[index] = 0;

            // Update UI display (optional before reload)
            if (holeInfoScript != null)
                holeInfoScript.UpdateHoleInfoDisplay();

            // Suppress auto-menu if we're about to reload Hub during Practice Mode
            if (isPracticeMode && GameManager.Instance.holeScenes[index] == "Hub")
                PracticeState.suppressAutoMenu = true;

            // Reload the current scene
            string sceneToReload = GameManager.Instance.holeScenes[index];
            SceneManager.LoadScene(sceneToReload);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // fallback
        }
    }


    public void ResetEntireGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
            SceneManager.LoadScene("Hub");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
