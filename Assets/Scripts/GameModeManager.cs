using UnityEngine;

// GameModeManager controls whether the game is practice mode or play mode and persists between scenes
public class GameModeManager : MonoBehaviour
{
    // Singleton instance
    public static GameModeManager Instance { get; private set; }

    // Private backing field for IsPracticeMode
    private bool isPracticeMode;

    // Public property with getter and setter including Debug.Log
    public bool IsPracticeMode
    {
        get { return isPracticeMode; }
        set
        {
            isPracticeMode = value;
            Debug.Log("Mode set to: " + (isPracticeMode ? "Practice Mode" : "Game Mode"));
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist between scenes
        }
    }
}
