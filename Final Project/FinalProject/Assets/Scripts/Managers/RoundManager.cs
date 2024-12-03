using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{    
    private GameManager gameManager; // The levels current game manager
    private TimerManager timerManager; // The game's timer

    public int currentRound; // The round the player is playing
    public TextMeshProUGUI roundText; // UI text to show the current round being player
    public delegate void PowerUpSpawner(); // Template for spawning and destroying powerups
    public static event PowerUpSpawner powerUpSpawnerDelegate; // For spawning powerups
    public static event PowerUpSpawner powerUpDeleterDelegate; // For destroying powerups


    // Start is called before the first frame update
    void Start()
    {
        currentRound = 1; // Starts the game at round 1
        gameManager = gameObject.GetComponent<GameManager>(); // Gets the level's game manager
        timerManager = gameObject.GetComponent<TimerManager>(); // Gets the game's timer
        StartRound(); // Begins the first round
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.CheckIfAllEnemiesDead(); // Checks if all the enemies are dead
    }

    // Begins the current round
    void StartRound()
    {
        roundText.text = "Round: " + currentRound; // Sets the text to the value of the current round
        gameManager.SpawnEnemyWave(); // Spawns a wave of enemies
        gameManager.GetEnemiesInLevel(); // Gets the amount of enemies in the level
        timerManager.ResetTime(); // Resets the timer every round
        powerUpSpawnerDelegate(); // Spawns power ups
    }

    // Increments the current round to set it to next round
    public void UpdateRound()
    {
        currentRound++; // Increments the current round
        if(GameObject.FindGameObjectWithTag("PowerUp"))
        {
            powerUpDeleterDelegate(); // Destroys remaing powerups before next round
        }       
        StartRound(); // Starts the next round
    }
}
