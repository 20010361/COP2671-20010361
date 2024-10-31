using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemiesArray; // The collection of enemy types that can be spawned in


    // When the object is enabled
    private void OnEnable()
    {
        GameManager.enemySpawnerDelegate += SpawnEnemy; // Subscribes to the game manager's delegate for spawning enemies
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawned an enemy
    void SpawnEnemy()
    {
        Instantiate(EnemiesArray[0], this.gameObject.transform.position, this.gameObject.transform.rotation); // Spawned an enemy
    }
}
