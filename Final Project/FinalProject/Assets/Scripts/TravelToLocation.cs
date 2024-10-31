using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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

    // Detects if the enemy has collided with air space
    private void OnTriggerEnter(Collider other)
    {
        // If the enemy has entered the air space
        if(other.gameObject.CompareTag("AreaOfOperation"))
        {
            gameObject.AddComponent<AIController>(); // Adds the ai component
            Destroy(this); // Deletes this component
        }
    }
}
