using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreCardUI scoreCardUI;

    public int currentHoleIndex = 0; // 0 = Hub, 1 = Hole1, 2 = Hole2, 3 = Hole3
    public string[] holeScenes = { "Hub", "Hole1", "Hole2", "Hole3" };
    public Dictionary<int, int> holeScores = new Dictionary<int, int>(); // holeIndex -> strokes

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scoreCardUI != null)
        {
            if (scene.name == "Hub" || scene.name.StartsWith("Hole"))
            {
                scoreCardUI.gameObject.SetActive(true);  // Show ScoreCard
            }
            else
            {
                scoreCardUI.gameObject.SetActive(false);  // Hide ScoreCard in MainMenu or other scenes
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResetGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterShot()
    {
        if (!holeScores.ContainsKey(currentHoleIndex))
            holeScores[currentHoleIndex] = 0;

        holeScores[currentHoleIndex]++;
    }

    public void AdvanceHole()
    {
        // Before advancing, update the ScoreCard with the current hole's score
       // if (currentHoleIndex != 0 && scoreCardUI != null)
       // {
       //     int strokes = holeScores.ContainsKey(currentHoleIndex) ? holeScores[currentHoleIndex] : 0;
       //     scoreCardUI.UpdateScore(currentHoleIndex, strokes);
       // }

        currentHoleIndex++;
        if (currentHoleIndex >= holeScenes.Length)
        {
            Debug.Log("All holes complete! Returning to Hole 1 and resetting scores.");
            currentHoleIndex = 0;
            ResetGame();
        }
        else
        {
            // Reset shot count for the new hole
            holeScores[currentHoleIndex] = 0;
        }

        SceneManager.LoadScene(holeScenes[currentHoleIndex]);
    }

    public void ResetGame()
    {
        holeScores.Clear();
        currentHoleIndex = 0;
    }

    public int GetScore(int holeIndex)
    {
        return holeScores.ContainsKey(holeIndex) ? holeScores[holeIndex] : 0;
    }
}
