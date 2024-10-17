using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameObject gameManagerObject; // Variable to reference game manager object
    private GameManager gameManager; // Variable to reference game manager component


    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager"); // Finds the object the game manager is attatched to in game world
        gameManager = gameManagerObject.GetComponent<GameManager>(); // Gets the game manager component
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detects a collision between two game objects with colliders
    public void OnTriggerEnter(Collider other)
    {
        // If colliding with a plane
        if(other.CompareTag("Plane"))
        {
            gameManager.ApplyDamageToVictim(10, other.gameObject); // Tells the game manager to apply damage to other object
            Destroy(gameObject); // Destroys owner game object
        }
        // If colliding with a wall
        if(other.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destroys owner game object
        }
    }
}
