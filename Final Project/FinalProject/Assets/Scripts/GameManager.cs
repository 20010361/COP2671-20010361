using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void EnemySpawnerDelegate(); // Delegate template for spawning enemies
    public static event EnemySpawnerDelegate enemySpawnerDelegate; // Delegate for spawning enemies

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(); // Spawns an enemy wave
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns a wave of enemies
    void SpawnEnemyWave()
    {
        enemySpawnerDelegate(); // Sends a call to all observers subscribed to this delegate
    }
}
