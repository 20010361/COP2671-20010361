using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float bulletDamage = 5; // The damage the bullet deals

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detects if the bullet has collided with something
    public void OnTriggerEnter(Collider other)
    {
        // Executes if bullet collided with a plane
        if(other.CompareTag("Plane") || other.CompareTag("Player"))
        {
            HealthSystem healthSystem = other.GetComponent<HealthSystem>(); // Gets the health component of victim object
            healthSystem.ApplyDamage(bulletDamage); // Applies damage to the other plane
        }
        // Executes if bullet collided with a wall
        if(other.CompareTag("Wall"))
        {
            // To do: Play a particle effect and sound
        }
        Destroy(gameObject); // Destroys the bullet
    }
}
