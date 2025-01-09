using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float timeRemaining = 60f;
    private bool timerIsRunning = true;
    public Button shootButton;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeText.text = "Time remaining: " + Mathf.FloorToInt(timeToDisplay);
    }

    void EndGame()
    {
        // Logic to handle the end of the game
                shootButton.interactable = false;
        Debug.Log("Game Over");
    }
}
