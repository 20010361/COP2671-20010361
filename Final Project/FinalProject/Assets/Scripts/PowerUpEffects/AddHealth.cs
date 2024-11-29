using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : PowerUpEffect
{
    GameObject player; // Reference to player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); // Finds player in the game world using its tag
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Restores the player's health to full
    public override void EnablePower()
    {
        player.GetComponent<HealthSystem>().RestoreHealth(); // Gets the health system of the player and restores player health
    }
}
