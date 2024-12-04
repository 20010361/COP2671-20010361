using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject[] enemiesArray; // The collection of enemy types that can be spawned in
    private RoundManager roundManager; // The current round manager in the game world

    public GameObject[] stage1EnemiesArray; // The array of enemies to be spawned in the early rounds
    public GameObject[] stage2EnemiesArray; // The array of enemies to be spawned in the mid rounds
    public GameObject[] stage3EnemiesArray; // The array of enemies to be spawned in the later rounds
    public GameObject[] stage4EnemiesArray; // The array of enemies to be spawned in the later rounds



    // When the object is enabled
    private void OnEnable()
    {
        GameManager.enemySpawnerDelegate += SpawnEnemy; // Subscribes to the game manager's delegate for spawning enemies
    }

    // Start is called before the first frame update
    void Start()
    {
        roundManager = GameObject.Find("GameManager").GetComponent<RoundManager>(); // Gets the current round manager
    }

    // Spawned an enemy
    void SpawnEnemy()
    {
        if(roundManager.currentRound <= 5)
        {
            enemiesArray = stage1EnemiesArray;
        }
        else if(roundManager.currentRound <= 10 && roundManager.currentRound > 5)
        {
            enemiesArray = stage2EnemiesArray;
        }
        else if(roundManager.currentRound <= 15 && roundManager.currentRound > 10)
        {
            enemiesArray = stage3EnemiesArray;
        }
        else if (roundManager.currentRound > 15)
        {
            enemiesArray = stage4EnemiesArray;
        }

        int chosenPlane = Random.Range(0, enemiesArray.Length); // Randomizes which plane in list is spawned in
        Instantiate(enemiesArray[chosenPlane], this.gameObject.transform.position, this.gameObject.transform.rotation); // Spawned an enemy
    }

    // When the object is disabled
    private void OnDisable()
    {
        GameManager.enemySpawnerDelegate -= SpawnEnemy; // Unsubscribes from the game manager's delegate for spawning enemies
    }
}