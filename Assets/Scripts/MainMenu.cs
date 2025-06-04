using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PracticeGame()
    {
        if (GameModeManager.Instance != null && GameManager.Instance != null)
        {
            GameModeManager.Instance.IsPracticeMode = true;
            GameManager.Instance.ResetGame();  // Reset hole index and scores
            SceneManager.LoadScene("Hub");
        }
        else
        {
            Debug.LogError("Missing GameModeManager or GameManager instance.");
        }
    }

    public void PlayGame()
    {
        if (GameModeManager.Instance != null && GameManager.Instance != null)
        {
            GameModeManager.Instance.IsPracticeMode = false;
            GameManager.Instance.ResetGame();  // Reset hole index and scores
            SceneManager.LoadScene("Hub");
        }
        else
        {
            Debug.LogError("Missing GameModeManager or GameManager instance.");
        }
    }

    public void ResumeGame()
    {
        if (GameModeManager.Instance != null && GameManager.Instance != null)
        {
            int resumeIndex = GameManager.Instance.currentHoleIndex;
            if (resumeIndex >= 0 && resumeIndex < GameManager.Instance.holeScenes.Length)
            {
                SceneManager.LoadScene(GameManager.Instance.holeScenes[resumeIndex]);
            }
            else
            {
                Debug.LogError("Invalid resume scene index.");
            }
        }
        else
        {
            Debug.LogError("Missing GameManager or GameModeManager instance.");
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
