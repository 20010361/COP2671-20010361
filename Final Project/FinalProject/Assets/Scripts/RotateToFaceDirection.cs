using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFaceDirection : MonoBehaviour
{
    // Upper most level(z): 20
    // lower most level(z): -20
    // right most level(x): 46
    // left most level(x): -46
    private float topZ = 12; // The max position at the top an object can be at
    private float rightX = 38; // The max position to the right an object can be at
    private Quaternion destination; // Where the object is going to be facing
    private float turnSpeed = 0.05f; // The speed at which an object can change direction
    private float timeCount = 0.0f; // The interpolation ratio

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Rotate", 1, 2); // Rotates the object repeatedly
    }

    // Update is called once per frame
    void Update()
    {
        // If the object is too far up or down
        if(transform.position.z >= topZ || transform.position.z <= -topZ)
        {
            Rotate();
        }
        // If the object is too far right or left
        if (transform.position.x >= rightX || transform.position.x <= -rightX)
        {
            Rotate();
        }
    }

    // Rotates the object
    void Rotate()
    {
        Vector3 direction = (GenerateNewDestination() - transform.position); // Gets the vector direction of travel
        Vector3 substracter = new Vector3(0, direction.y, 0); // Keeps the rotation on the desired axis
        destination = Quaternion.LookRotation(direction - substracter); // Gets the desired rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, destination, timeCount * turnSpeed); // Rotates the object smoothly toward destination
        timeCount += Time.deltaTime; // Adds delta time to time count
    }

    // Generates a random coordinate in the world
    Vector3 GenerateNewDestination()
    {
        Vector3 newDestination = new Vector3(Random.Range(-rightX + 1, rightX), 0, Random.Range(-topZ + 1, topZ)); // Creates a new randomized destination
        return newDestination; // Returns the new randomized destination
    }
}
