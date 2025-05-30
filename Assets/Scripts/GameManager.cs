using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentHoleIndex = 0; // 0 = Hub, 1 = Hole1, 2 = Hole2, 3 = Hole3
    public string[] holeScenes = { "Hub", "Hole1", "Hole2", "Hole3" };
    public Dictionary<int, int> holeScores = new Dictionary<int, int>(); // holeIndex -> strokes

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
        currentHoleIndex++;
        if (currentHoleIndex >= holeScenes.Length)
        {
            Debug.Log("All holes complete! Returning to Hub and resetting scores.");
            currentHoleIndex = 0;
            ResetGame();
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
