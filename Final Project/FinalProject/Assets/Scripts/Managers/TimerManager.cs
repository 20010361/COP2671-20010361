using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    private GameObject player; // Reference to the player
    private float timeLeft; // The timer remaining in the round

    public float maxTime = 40; // The time that the player will have each round
    public bool timerOn = false; // Whether the timer is counting down
    public TextMeshProUGUI timerText; // Text to display the timer

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Gets the player in the scene
        timerOn = true; // Starts the timer
    }

    // Update is called once per frame
    void Update()
    {
        // Executes only when the timer is on
        if(timerOn)
        {
            // Executes when there is timer left
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime; // Counts down
                UpdateTimer(timeLeft); // Displays the time
            }
            // Executes when time has run out
            else
            {
                timeLeft = 0; // Sets the time to zero so it doesn't go below it
                timerOn = false; // Turns off the timer
                player.GetComponent<HealthSystem>().KillPlayer(); // Ends the game
            }
        }
    }

    // Updates the timer visible to screen
    void UpdateTimer(float currenttime)
    {
        currenttime += 1; // So no weirdness or inaccuracies happen when converting the float time

        // Converts the time left into a time format
        float minutes = Mathf.FloorToInt(currenttime / 60);
        float seconds = Mathf.FloorToInt(currenttime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds); // Shows the time left on UI
    }

    // Resets the timer
    public void ResetTime()
    {
        timeLeft = maxTime; // Sets the timer back to its max
    }
}
