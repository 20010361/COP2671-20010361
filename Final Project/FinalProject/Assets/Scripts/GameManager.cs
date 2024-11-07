using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentRound; // The round the player is playing
    private int enemiesRemaining; // The amount of enemies left in level

    public TextMeshProUGUI roundText; // UI text to show the current round being player
    public delegate void EnemySpawnerDelegate(); // Delegate template for spawning enemies
    public static event EnemySpawnerDelegate enemySpawnerDelegate; // Delegate for spawning enemies    


    // Start is called before the first frame update
    void Start()
    {
        currentRound = 1; // Starts the game at round 1
        StartRound(); // Begins a round
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfAllEnemiesDead();
    }

    // Begins the current round
    void StartRound()
    {
        roundText.text = "Round: " + currentRound; // Sets the text to the value of the current round
        SpawnEnemyWave(); // Spawns a wave of enemies
        GetEnemiesInLevel(); // Gets the amount of enemies in the level
    }

    // Increments the current round to set it to next round
    void UpdateRound()
    {
        currentRound++; // Increments the current round
        StartRound(); // Starts the next round
    }

    // Gets the enemies that have been spawned in at the start of a round
    void GetEnemiesInLevel()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Plane").Length; // Finds the amount of enemies in level
    }

    // Decrements the number of enemies in the level
    public void UpdateEnemyCount()
    {
        enemiesRemaining--; // Decrements the count of enemies
    }

    // Checks if all the enemies are dead
    void CheckIfAllEnemiesDead()
    {
        // If all the enemies are dead
        if (enemiesRemaining < 1)
        {
            UpdateRound();
        }
    }

    // Spawns a wave of enemies
    void SpawnEnemyWave()
    {
        enemySpawnerDelegate(); // Sends a call to all observers subscribed to this delegate
    }
}
