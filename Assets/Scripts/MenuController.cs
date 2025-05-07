using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject helpCanvas;

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

    public void ExitGame()
    {
        Application.Quit();
    }
}
