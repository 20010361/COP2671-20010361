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


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        currentHealth = maxHealth; // Sets current health to max health

        if(gameObject.CompareTag("Player"))
        {
            playerHealthDelegate(currentHealth);
        }      
    }

    // Update is called once per frame
    void Update()
    {
        
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
            gameManager.UpdateEnemyCount();
        }

        Destroy(gameObject); // Destroys the object
    }
}
