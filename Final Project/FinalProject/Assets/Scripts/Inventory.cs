using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private PowerUp powerUp; // The powerup currently in the inventory

    public bool bIsEmpty = true; // Whether the inventory is full

    
    // Adds the powerup to the inventory
    public void AddToInventory(PowerUp powerup)
    {
        powerUp = powerup; // Sets the powerup to the given powerup
        bIsEmpty = false; // Shows that the inventory is now full
    }

    // Removes the powerup from the inventory
    public void RemoveFromInventory()
    {
        powerUp.powerUpEffect.EnablePower(); // Activates the powerup
        bIsEmpty = true; // Shows that the inventory is now empty
    }
}
