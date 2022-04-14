using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Modes gameStatus = Modes.paused;

    public int score;
    public int pickup;
    public int highScore, highPickup;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        GetHighScores();
    }

    public void StartGame()
    {
        gameStatus = Modes.running;

        GetComponent<BlockSpawner>().StartSpawning();

        gameObject.GetComponent<TrailScript>().CallTrailing();
    }

    public void EndGame()
    {
        gameStatus = Modes.over;

        GetComponent<BlockSpawner>().StopSpawning();

        StopAndSaveScore();
    }

    public void IncrementScore()
    {
        score++;
        print("Score is: " + score);
    }

    public void IncrementPickup()
    {
        pickup++;
    }

    void StopAndSaveScore()
    {
        // write to disk at the end
        if (score >= highScore)
            PlayerPrefs.SetInt("highScore", score);

        if (pickup >= highPickup)
            PlayerPrefs.SetInt("highPickup", pickup);
    }


    public void GetHighScores()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            highPickup = PlayerPrefs.GetInt("highPickup");
        }
    }
}