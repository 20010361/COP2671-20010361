using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MoveForward : MonoBehaviour
{
    // Player: 15.0f
    public float speed; // Variable for object speed
    // Player: (0,0,1)
    // Bullet: (0,0,1)
    private Vector3 travelDirection = new Vector3(0, 0, 1); // Variable for object travel direction


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(travelDirection * Time.deltaTime * speed); // Makes object travel forward
    }
}
