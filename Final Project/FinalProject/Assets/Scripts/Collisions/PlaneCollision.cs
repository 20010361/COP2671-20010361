using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    private float crashDamage = 10; // The damage dealt when the plane crashes into something
    
    public bool bCanCollide = true; // Determines if the plane can collide

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the plane collides with something
    private void OnTriggerEnter(Collider other)
    {       
        // Checks if the other object is either another plane or a wall
        if((other.gameObject.CompareTag("Plane") || other.gameObject.CompareTag("Wall")) && bCanCollide)
        {
            HealthSystem healthSystem = GetComponent<HealthSystem>(); // Gets parent object's health system
            MoveForward moveForward = GetComponent<MoveForward>(); // Gets parent object's movement
            healthSystem.ApplyDamage(crashDamage); // Applies damage to parent object
            moveForward.MoveBackward();
        }
    }
}
