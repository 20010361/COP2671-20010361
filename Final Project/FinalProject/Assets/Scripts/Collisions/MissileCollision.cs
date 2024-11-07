using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    public float missileDamage = 50; // The damage the missile deals

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detects if the missile collides with something
    public void OnTriggerEnter(Collider other)
    {
        // Executes if missile collided with a plane
        if (other.CompareTag("Plane") || other.CompareTag("Player"))
        {
            HealthSystem healthSystem = other.GetComponent<HealthSystem>(); // Gets the health component of victim object
            healthSystem.ApplyDamage(missileDamage); // Applies damage to the other plane
        }
        // Executes if missile collided with a wall
        if (other.CompareTag("Wall"))
        {
            // To do: Play a particle effect and sound
        }
        Destroy(gameObject); // Destroys the missile
    }
}
