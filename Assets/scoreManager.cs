using UnityEngine;
using UnityEngine.UI;


namespace ScoreCount { 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text textMeshPro;

    private int score = 0;

    private void Start()
    {
        textMeshPro = GetComponent<Text>();
    }
    void Awake()
    {
        // Ensure there is only one ScoreManager in the game
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Current Score: " + score);
        string ScoreCount = score.ToString();
        textMeshPro.text = ScoreCount;
    }

    public int GetScore()
    {
        return score;
    }

    // Example of a method to reset the score
    public void ResetScore()
    {
        score = 0;
    }
}

}