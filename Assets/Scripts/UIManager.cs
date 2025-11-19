using UnityEngine;
using TMPro;  


public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;      
    public TMP_Text timerText;     
    public TMP_Text healthText;     
    public GameManager gm;       
    public Player player;       

    private bool uiEnabled = true;


    void Start()
    {
        UpdateAllUI();
    }

    void Update()
    {
        if (uiEnabled)
            UpdateAllUI();
    }

    private void UpdateAllUI()
    {
        UpdateScore();
        UpdateTimer();
        UpdateHealth();
    }

    // Method WITH PARAMETERS
    public void SetUIEnabled(bool value)
    {
        uiEnabled = value;
    }

    // Method WITH RETURN VALUE
    public bool IsUIEnabled()
    {
        return uiEnabled;
    }

    // OVERLOADED METHOD
    public void ShowMessage(string message)
    {
        Debug.Log("UI Message: " + message);
    }

    public void ShowMessage(string message, int number)
    {
        Debug.Log("UI Message: " + message + " (" + number + ")");
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + gm.GetScore();
    }

    private void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.Ceil(gm.gameTime);
    }

    private void UpdateHealth()
    {
        healthText.text = "Health: " + player.GetHealth();
    }
}
