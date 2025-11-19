using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;       // reference to Player
    public float gameTime = 120f;
    private bool isGameActive = false;
    public int score = 0;
    public string gameState = "None";  


    void Start()
    {
        Time.timeScale = 1f;
        StartGame();
    }

    void Update()
    {
        if (isGameActive)
        {
            RunTimer();
            CheckGameState();
        }
    }

    // 1. Start the game
    public void StartGame()
    {
        isGameActive = true;
        gameState = "Playing";
        score = 0;
    }

    // 2. Method WITH PARAMETERS (required)
    public void AddScore(int amount)
    {
        score += amount;
    }

    // 3. Method WITH RETURN VALUE (required)
    public bool IsGameActive()
    {
        return isGameActive;
    }

    // 4. OVERLOADED METHOD (required)
    public void EndGame()
    {
        isGameActive = false;
        gameState = "Lose";
        Debug.Log("Game Over: You Lose!");
    }

    public int GetScore()
    {
        return score;
    }

    // Overloaded version
    public void EndGame(string reason)
    {
        isGameActive = false;
        gameState = reason;
        Debug.Log("Game ended: " + reason);
        Time.timeScale = 0f;
        SceneManager.LoadScene("failed");
    }

    // 5. Checks win/lose logic
    private void CheckGameState()
    {
        if (player.IsDead())
            EndGame("Player Died");

        if (gameTime <= 0)
            EndGame("Time Up");

        if (score >= 100)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("won");
        }
    }


    // ====== TIMER ======
    private void RunTimer()
    {
        gameTime -= Time.deltaTime;

        if (gameTime < 0)
            gameTime = 0;
    }
}
