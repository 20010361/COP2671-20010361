using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissiles : MonoBehaviour
{
    private GameObject parentObject; // Object the script is the child of
    private Vector3 missileBay1Position; // Position of the first missile bay for missiles to come out of
    private Vector3 missileBay2Position; // Position of the second missile bay for missiles to come out of
    private Quaternion planeRotation; // Rotation of plane for missiles to face in correct direction
    private int currentMissileBay = 1; // The current bay for missile to fire from

    public GameObject missilePrefab; // Missile that will be spawned


    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.transform.root.gameObject; // Gets the object the script is child of
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fires the plane's missiles
    public void FireMissile()
    {
        missileBay1Position = parentObject.transform.Find("MissileBay1").position; // Gets the position of missile bay 1
        missileBay2Position = parentObject.transform.Find("MissileBay2").position; // Gets the position of missile bay 2
        planeRotation = parentObject.transform.rotation; // Gets the rotation of the plane

        // If current missile bay is the first
        if(currentMissileBay == 1)
        {
            Instantiate(missilePrefab, missileBay1Position, planeRotation); // Spawns missile
            currentMissileBay = 2; // Changes the current missile bay to two
        }
        // If the current missile bay is the second
        else
        {
            Instantiate(missilePrefab, missileBay2Position, planeRotation); // Spawns missile
            currentMissileBay = 1; // Changes the current missile bay to one
        }
    }
}
