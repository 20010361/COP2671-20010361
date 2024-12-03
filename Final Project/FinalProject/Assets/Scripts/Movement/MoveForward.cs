using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class MoveForward : MonoBehaviour
{
    // Player: (0,0,1)
    // Bullet: (0,0,1)
    private Vector3 travelDirection = new Vector3(0, 0, 1); // Variable for object travel direction
    
    // Player: 15.0f
    public float speed; // Variable for object speed
       

    // Update is called once per frame
    void Update()
    {
        Move(); // Moves every frame
    }

    // Moves the object
    void Move()
    {
        transform.Translate(travelDirection * Time.deltaTime * speed); // Makes object travel forward
    }

    // Moves the object backward
    public void MoveBackward()
    {
        Vector3 reverseDirection = new Vector3(0, 0, -30);
        transform.position = Vector3.Lerp(transform.position, reverseDirection, Time.deltaTime * 2f); // Makes object travel backward
    }
}
