using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFaceDirection : MonoBehaviour
{
    // Upper most level(z): 20
    // lower most level(z): -20
    // right most level(x): 46
    // left most level(x): -46
    private float topZ = 10; // The max position at the top an object can be at
    private float rightX = 36; // The max position to the right an object can be at
    private Quaternion destination; // Where the object is going to be facing

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FlyAround", 1, 1); // Rotates the object repeatedly
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
        destination = Quaternion.LookRotation(direction - substracter); // Gets the desired rotation
        transform.rotation = destination; // Rotates the object to travel to destination
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
        if(transform.position.z >= topZ || transform.position.z <= -topZ)
        {
            RotateToDirection();
        }
        if(transform.position.x >= rightX || transform.position.x <= -rightX)
        {
            RotateToDirection();
        }
    }
}
