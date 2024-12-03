using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{   
    private float currentHealth; // The object's current health
    private bool bIsAlive = true; // Variable for whether the object is dead or alive
    private GameManager gameManager; // The game manager

    public float maxHealth = 100; // The maximum health the object can have
    public bool bIsInvincible = false; // Determines whether the object can take damage
    public delegate void PlayerHealthTemplate(float health); // Template for player health delegate
    public static event PlayerHealthTemplate playerHealthDelegate; // Delegate to tell listener that player is being damaged
    public GameObject deathMenu; // The death menu that will be displayed upon death


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        currentHealth = maxHealth; // Sets current health to max health

        // Executes only if the parent is the player
        if(gameObject.CompareTag("Player"))
        {
            playerHealthDelegate(currentHealth); // Displays player health when game starts
        }      
    }

    // Subtracts from current health
    public void ApplyDamage(float damage)
    {
        // Only applys damage when the object is alive and not invincible
        if (bIsAlive && !bIsInvincible)
        {
            currentHealth -= damage; // Subtracts the damage from current health

            // Exectutes if the parent object is the player
            if(gameObject.CompareTag("Player"))
            {
                playerHealthDelegate(currentHealth); // Tells all listeners the player's current health
            }

            // If the object loses all of its health
            if(currentHealth <= 0)
            {
                if(gameObject.CompareTag("Player"))
                {
                    playerHealthDelegate(0); // Tells all listens the player's health is zero when dead so it looks nice
                }               
                Die(); // Makes the object die
            }          
        }
    }

    // Puts object in death state
    void Die()
    {
        bIsAlive = false; // Makes the object dead

        // If the parent object is an enemy
        if(gameObject.CompareTag("Plane"))
        {
            gameManager.UpdateEnemyCount(); // Subtracts from the count of enemies currently in the level
        }
        // If the parent object is the player
        else if(gameObject.CompareTag("Player"))
        {
            deathMenu.SetActive(true); // Shows the death screen
            Time.timeScale = 0; // Stops the game time
        }

        Destroy(gameObject); // Destroys the object
    }

    // Restores current health to full
    public void RestoreHealth()
    {
        currentHealth = maxHealth; // Sets current health back to back
        playerHealthDelegate(currentHealth); // Displays the current health
    }

    // Kills the player
    public void KillPlayer()
    {
        ApplyDamage(maxHealth); // Instantly kills the player
    }
}
