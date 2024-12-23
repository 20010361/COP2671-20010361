using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Presets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ShootBullets mainGun; // Object for firing the main gun
    private FireMissiles missileBay; // Object for firing the missiles

    public LayerMask layersToHit; // Layer object that raycast is meant to collide with
    public GameObject pauseMenu; // Object for pausing and unpausing the game
    public ShowStats showStats; // Object for showing level stats


    private void OnEnable()
    {
        Time.timeScale = 1; // Resumes game time
    }

    // Start is called before the first frame update
    void Start()
    {
        mainGun = GetComponent<ShootBullets>(); // Gets the component for firing the main gun
        missileBay = GetComponent<FireMissiles>(); // Gets the component for firing the missiles
    }

    // Update is called once per frame
    void Update()
    {
        // When game is paused player input is disabled
        if(Time.timeScale > 0)
        {
            FlyPlane();
            UseWeapons();            
            MaintainHeight();
        }
        PauseGame(); // Put outside if statement so the player can still use tab to unpause the game
    }

    // Moves the player to where the mouse cursor is on screen
    void FlyPlane()
    {
        Vector3 screenPosition = Input.mousePosition; // Gets the position of the mouse cursor on the computer screen
        Ray ray = Camera.main.ScreenPointToRay(screenPosition); // Sends out a ray toward the mouse cursor position

        // Checks if the ray hit the specified layer
        if(Physics.Raycast(ray, out RaycastHit Hitdata, 100, layersToHit))
        {
            Vector3 worldPosition = Hitdata.point; // Sets the world postion to the position hit by the cast
            Vector3 direction = (worldPosition - transform.position) + new Vector3(0,10,0); // Calculates the direction the player need to travel to get to the world position
            Vector3 substracter = new Vector3(0, direction.y, 0); // This variable keeps the player rotating only on the y axis by subtracting it from the direction, somehow...

            // Gets rid of that debug message about the zero look rotation
            if(direction - substracter != Vector3.zero)
            {
                Quaternion destination = Quaternion.LookRotation(direction - substracter); // Gets the rotation values needed to get player to target destination               
                transform.rotation = Quaternion.Lerp(transform.rotation, destination, Time.deltaTime * 2.5f); // Rotates the player toward the target destination
            }    
        }
    }

    // Shoots the plane's main gun or missiles
    void UseWeapons()
    {
        // If player holds down the left mouse button, the main gun will shoot
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(mainGun.FireGun()); // Fires the gun
        }
        // If the player presses the right mouse button, a missile will fire
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(missileBay.LaunchMissile()); // Fires the missiles
        }
    }

    // Pauses the game
    void PauseGame()
    {
        // Executes when key is pressed and game is unpaused
        if(Input.GetKeyDown(KeyCode.Tab) && pauseMenu.activeSelf == false)
        {
            pauseMenu.SetActive(true); // Opens the pause menu
            showStats.Show(); // Shows the stats in the pause menu
            Time.timeScale = 0; // Stops game time
        }
        // Executes when the key is pressed and game is already paused
        else if(Input.GetKeyDown(KeyCode.Tab) && pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false); // Closes the pause menu
            Time.timeScale = 1; // Resumes game time
        }
    }

    // Makes sure the player's plane stays on the intended height of the game
    void MaintainHeight()
    {
        // Executes when the player's elevation has changed
        if(gameObject.transform.position.y != 1f)
        {
            gameObject.transform.position = new Vector3(transform.position.x, 1, transform.position.z); // Sets it back to one
        }
    }
}
