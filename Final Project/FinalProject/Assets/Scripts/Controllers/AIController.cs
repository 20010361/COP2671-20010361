using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private float topZ = 10; // The max position at the top an object can be at
    private float rightX = 36; // The max position to the right an object can be at
    private ShootBullets mainGun; // Object to shoot bullets
    private FireMissiles missileBay; // Object to fire missiles


    // Start is called before the first frame update
    void Start()
    {
        mainGun = GetComponent<ShootBullets>(); // Gets the component for firing the main gun
        missileBay = GetComponent<FireMissiles>(); // Gets the component for firing the missiles
        StartCoroutine(AIBehavior()); // Starts the ai behavior
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Rotates the object
    void RotateToDirection()
    {
        Vector3 direction = (GenerateNewDestination() - transform.position); // Gets the vector direction of travel
        Vector3 substracter = new Vector3(0, direction.y, 0); // Keeps the rotation on the desired axis
        Quaternion destination = Quaternion.LookRotation(direction - substracter); // Gets the desired rotation
        transform.rotation = destination; // Rotates the object to travel to destination
    }

    // Rotates the object to face the player
    void RotateToFacePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Finds the player using its tag
        Vector3 playerLocation = player.transform.position; // Gets the player's position in game world
        Vector3 direction = (playerLocation - transform.position); // Gets the direction of travel
        Vector3 substracter = new Vector3(0, direction.y, 0); // Keeps the rotation on the desired axis
        Quaternion destination = Quaternion.LookRotation(direction - substracter); // Gets the desired rotation
        transform.rotation = destination; // Rotates object to face the destination
    }

    // Generates a random coordinate in the world
    Vector3 GenerateNewDestination()
    {
        Vector3 newDestination = new Vector3(Random.Range(-rightX + 1, rightX), 0, Random.Range(-topZ + 1, topZ)); // Creates a new randomized destination
        return newDestination; // Returns the new randomized destination
    }

    // Makes object move around within bordered area
    void FlyAround()
    {
        // If the object gets too close to the top and bottom border
        if (transform.position.z >= topZ || transform.position.z <= -topZ)
        {
            RotateToDirection();
        }
        // If the object gets too close to the right and left border
        if (transform.position.x >= rightX || transform.position.x <= -rightX)
        {
            RotateToDirection();
        }
    }

    // Makes enemy attack player
    void Attack()
    {
        int choiceInWeapon = Random.Range(1, 3); // Determines what weapon the enemy uses
        
        // For the main gun
        if(choiceInWeapon == 1)
        {
            StartCoroutine(mainGun.FireGun()); // Fires the main gun
        }
        // For the missile bay
        if(choiceInWeapon == 2)
        {
            StartCoroutine(missileBay.LaunchMissile()); // Launches a missile
        }

        
    }

    // Handles the enemy AI
    IEnumerator AIBehavior()
    {
        // Keeps the ai running infinitely
        while(true)
        {
            int decision = Random.Range(1, 3); // Generates a random number to determine what the ai does
            if(decision == 1)
            {
                FlyAround(); // Ai just flys around
            }
            else
            {
                GameObject player; // The player in the level

                // Checks if the player exists
                if (player = GameObject.FindGameObjectWithTag("Player"))
                {
                    RotateToFacePlayer(); // Ai faces the player
                    Attack(); // Attacks the player
                }                
            }            
            yield return new WaitForSeconds(1); // Waits before continueing  the loop         
        }
    }
}
