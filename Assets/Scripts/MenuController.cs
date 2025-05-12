using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject helpCanvas;
    private GolfBallController golfBallScript;
    private HoleInfoUI holeInfoScript;
    private AudioSource golfBallAudio;

    void Start()
    {
        golfBallScript = GameObject.Find("GolfBall").GetComponent<GolfBallController>();
        holeInfoScript = GameObject.Find("HoleInfoUIManager").GetComponent<HoleInfoUI>();
        golfBallAudio = GameObject.Find("GolfBall").GetComponent<AudioSource>();

        helpCanvas.SetActive(true);
        Time.timeScale = 0f;
        golfBallScript.enabled = false;

        Rigidbody rb = golfBallScript.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;

        if (golfBallAudio != null)
            golfBallAudio.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        bool isActive = !helpCanvas.activeSelf;
        helpCanvas.SetActive(isActive);

        Time.timeScale = isActive ? 0f : 1f;
        golfBallScript.enabled = !isActive;

        Rigidbody rb = golfBallScript.GetComponent<Rigidbody>();
        rb.constraints = isActive ? RigidbodyConstraints.FreezeAll : RigidbodyConstraints.None;

        if (golfBallAudio != null)
            golfBallAudio.enabled = !isActive; // Re-enable audio when menu closes

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

    public void ResetScene() {
        golfBallScript.ResetBall();
        holeInfoScript.ResetShots();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
