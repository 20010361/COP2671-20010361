using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MakeInvincible(); // Makes enemy invincible while traveling to air space
        GoToLocation(); // Travels to the air space
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Makes the object face toward its destination
    void GoToLocation()
    {
        Vector3 location = new Vector3(0, 1, 0); // The world origin
        Vector3 direction = (location - transform.position); // Gets the vector direction of travel
        Vector3 substracter = new Vector3(0, direction.y, 0); // Keeps the rotation on the desired axis
        Quaternion destination = Quaternion.LookRotation(direction - substracter); // Gets the desired rotation
        transform.rotation = destination; // Rotates the object
    }

    // Makes the enemy unable to take damage
    void MakeInvincible()
    {
        HealthSystem healthSystem = gameObject.GetComponent<HealthSystem>(); // Gets enemy health system
        healthSystem.bIsInvincible = true; // Makes enemy invincible
        PlaneCollision planeCollision = gameObject.GetComponent<PlaneCollision>(); // Gets parent object plane collision
        planeCollision.bCanCollide = false; // Makes the enemy unable to collide
    }

    // Makes the enemy able to take damage
    void MakeVincible()
    {
        HealthSystem healthSystem = gameObject.GetComponent<HealthSystem>(); // Gets enemy health system
        healthSystem.bIsInvincible = false; // Makes enemy vincible
        PlaneCollision planeCollision = gameObject.GetComponent<PlaneCollision>(); // Gets parent object plane collision
        planeCollision.bCanCollide = true; // Makes the enemy able to collide
    }

    // Detects if the enemy has collided with air space
    private void OnTriggerEnter(Collider other)
    {
        // If the enemy has entered the air space
        if(other.gameObject.CompareTag("AreaOfOperation"))
        {
            gameObject.AddComponent<AIController>(); // Adds the ai component
            MakeVincible(); // Makes the enemy vincible again once it reached its destination
            Destroy(this); // Deletes this component
        }
    }
}
