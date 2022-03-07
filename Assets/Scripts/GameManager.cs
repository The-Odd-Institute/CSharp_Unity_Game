using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 01-Beginning (1 of 4)
    public static GameManager instance;
    public Modes gameStatus = Modes.paused;



    // Scoring - 1 of 
    public int score;
    public int pickup;
    public int highScore, highPickup;


    // 01-Beginning (2 of 4)
    private void Awake()
    {
        if (instance == null)
            instance = this;

        // Scoring - 3 of 
        GetHighScores();
    }

    // 01-Beginning (3 of 4)
    public void StartGame()
    {
        gameStatus = Modes.running;

        // 03-Spawning (1 of 2)
        GetComponent<BlockSpawner>().StartSpawning();


        // Trail
        gameObject.GetComponent<TrailScript>().CallTrailing();
    }


    // 01-Beginning (4 of 4)
    public void EndGame()
    {
        gameStatus = Modes.over;

        // 03-Spawning (2 of 2)
        GetComponent<BlockSpawner>().StopSpawning();

        // Scoring
        StopAndSaveScore();
    }



    // Scoring - 4 of
    public void IncrementScore()
    {
        score++;
        print("Score is: " + score);
    }
    // Scoring - 5 of
    public void IncrementPickup()
    {
        pickup++;
    }

    // Scoring - 6 of
    void StopAndSaveScore()
    {
        // CancelInvoke("IncrementScore");
         //CancelInvoke("IncrementPickup");

        // write to disk at the end
        if (score >= highScore)
            PlayerPrefs.SetInt("highScore", score);

        if (pickup >= highPickup)
            PlayerPrefs.SetInt("highPickup", pickup);
    }


    // Scoring - 2 of 
    public void GetHighScores()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            highPickup = PlayerPrefs.GetInt("highPickup");
        }
    }
}