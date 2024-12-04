using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    public PowerUp[] powerUps; // The list of power ups that can be spawned


    private void OnEnable()
    {
        RoundManager.powerUpSpawnerDelegate += SpawnInPowerUp; // Listens for when the round is starting so it can spawn powerups
    }

    // Spawns in a power up
    public void SpawnInPowerUp()
    {
        // Determines whether a powerup spawns
        int spawnDecision = Random.Range(0, 3); // The odds of a powerup spawning
        if (spawnDecision == 1)
        {
            int powerUpToSpawn = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[powerUpToSpawn], this.gameObject.transform.position, Quaternion.LookRotation(Vector3.up));
        }      
    }

    private void OnDisable()
    {
        RoundManager.powerUpSpawnerDelegate -= SpawnInPowerUp; // No longer listens for when round is starting
    }
}
