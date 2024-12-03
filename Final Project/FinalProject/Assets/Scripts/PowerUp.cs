using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerUpEffect; // The effect the powerup has


    private void OnEnable()
    {
        RoundManager.powerUpDeleterDelegate += DestroyAfterRound; // Listens for when to destroy itself after current round is over
    }

    // Execute upon colliding with something
    private void OnTriggerEnter(Collider other)
    {
        // If the collision is with the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Checks if player inventory is empty before adding the powerup to it
            if(other.gameObject.GetComponent<Inventory>().bIsEmpty == true)
            {
                other.gameObject.GetComponent<Inventory>().AddToInventory(this); // Adds the powerup to the player's inventory
                Destroy(gameObject); // Destroys the powerup
            }           
        }
    }

    // Powerup destroys itself
    public void DestroyAfterRound()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        RoundManager.powerUpDeleterDelegate -= DestroyAfterRound; // No longer listen for when round is over
    }
}
