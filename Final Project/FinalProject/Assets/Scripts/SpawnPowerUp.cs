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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns in a power up
    public void SpawnInPowerUp()
    {
        Instantiate(powerUps[0], this.gameObject.transform.position, Quaternion.LookRotation(Vector3.up));
    }

    private void OnDisable()
    {
        RoundManager.powerUpSpawnerDelegate -= SpawnInPowerUp; // No longer listens for when round is starting
    }
}
