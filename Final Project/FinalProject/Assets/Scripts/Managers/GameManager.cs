using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int enemiesRemaining; // The amount of enemies left in level
    private RoundManager roundManager; // The level's round manager
  
    public TextMeshProUGUI healthText; // UI text to show player current health
    public delegate void EnemySpawnerDelegate(); // Delegate template for spawning enemies
    public static event EnemySpawnerDelegate enemySpawnerDelegate; // Delegate for spawning enemies    


    private void OnEnable()
    {
        HealthSystem.playerHealthDelegate += DisplayPlayerHealth; // Makes the game manager listen for when the player takes damage
    }

    // Start is called before the first frame update
    void Start()
    {
        roundManager = gameObject.GetComponent<RoundManager>(); // Gets the level's round manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Gets the enemies that have been spawned in at the start of a round
    public void GetEnemiesInLevel()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Plane").Length; // Finds the amount of enemies in level
    }

    // Decrements the number of enemies in the level
    public void UpdateEnemyCount()
    {
        enemiesRemaining--; // Decrements the count of enemies
    }

    // Checks if all the enemies are dead
    public void CheckIfAllEnemiesDead()
    {
        // If all the enemies are dead
        if (enemiesRemaining < 1)
        {
            roundManager.UpdateRound(); // Initiates the next round after all the enemies are dead
        }
    }

    // Spawns a wave of enemies
    public void SpawnEnemyWave()
    {
        enemySpawnerDelegate(); // Sends a call to all observers subscribed to this delegate
    }

    // Displays the player's current health
    void DisplayPlayerHealth(float health)
    {
        healthText.text = "Health: " + health; // Displays player health to UI
    }
}
