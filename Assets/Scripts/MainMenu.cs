using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PracticeGame()
    {
        if (GameModeManager.Instance != null)
        {
            GameModeManager.Instance.IsPracticeMode = true;  // Set Practice Mode
            SceneManager.LoadScene("Hub");  // Practice scene
        }
        else
        {
            Debug.LogError("GameModeManager instance is null. Ensure it exists in the MainMenu scene.");
        }
    }

    public void PlayGame()
    {
        if (GameModeManager.Instance != null)
        {
            GameModeManager.Instance.IsPracticeMode = false;  // Set Game Mode
            SceneManager.LoadScene("Hole1");  // Game scene
        }
        else
        {
            Debug.LogError("GameModeManager instance is null. Ensure it exists in the MainMenu scene.");
        }
    }


    public void ShowCredits()
    {
        Debug.Log("Credits button clicked.");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
