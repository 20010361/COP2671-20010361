using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 screenPosition; // Coordinates along the computer screen
    private Vector3 worldPosition; // Coordinates along the game world
    private Quaternion destination; // Variable used to rotate the player
    private ShootBullets mainGun; // Object for firing the main gun
    private FireMissiles missileBay; // Object for firing the missiles

    public LayerMask layersToHit; // Layer object that raycast is meant to collide with
    

    // Start is called before the first frame update
    void Start()
    {
        mainGun = GetComponent<ShootBullets>(); // Gets the component for firing the main gun
        missileBay = GetComponent<FireMissiles>(); // Gets the component for firing the missiles
    }

    // Update is called once per frame
    void Update()
    {
        FlyPlane();
        ShootMainGun();
        FireMissile();
    }

    // Moves the player to where the mouse cursor is on screen
    void FlyPlane()
    {
        screenPosition = Input.mousePosition; // Gets the position of the mouse cursor on the computer screen
        
        Ray ray = Camera.main.ScreenPointToRay(screenPosition); // Sends out a ray toward the mouse cursor position

        // Checks if the ray hit the specified layer
        if(Physics.Raycast(ray, out RaycastHit Hitdata, 100, layersToHit))
        {
            worldPosition = Hitdata.point; // Sets the world postion to the position hit by the cast
            Vector3 direction = (worldPosition - transform.position); // Calculates the direction the player need to travel to get to the world position
            Vector3 substracter = new Vector3(0, direction.y, 0); // This variable keeps the player rotating only on the y axis by subtracting it from the direction, somehow...
            destination = Quaternion.LookRotation(direction - substracter); // Gets the rotation values needed to get player to target destination
        }

        transform.rotation = destination; // Rotates the player toward the target destination
    }

    // Shoots the plane's gun
    void ShootMainGun()
    {
        // If player holds down the left mouse button, the main gun will shoot
        if(Input.GetMouseButton(0))
        {
            mainGun.FireGun(); // Fires the gun
        }
    }

    // Fires the plane's missiles
    void FireMissile()
    {
        // If the player presses the right mouse button, a missile will fire
        if(Input.GetMouseButtonDown(1))
        {
            missileBay.FireMissile(); // Fires the missiles
        }
    }
}
