using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissiles : MonoBehaviour
{  
    private int currentMissileBay = 1; // The current bay for missile to fire from
    private bool readyToLaunch = true; // Determines whether a missile is ready to be launched
    private AudioSource missileBayAudio; // The component that plays the missile launch sounds

    public GameObject missilePrefab; // Missile that will be spawned
    public float launchRate = 1; // The time between launches
    public AudioClip missileLaunchSound; // The sound of the missile being launched


    // Start is called before the first frame update
    void Start()
    {
        missileBayAudio = GetComponent<AudioSource>(); // Gets the audio source component on the parent object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Launches the plane's missiles
    public IEnumerator LaunchMissile()
    {
        // Executes when a missile is ready to be launched
        if(readyToLaunch == true)
        {
            readyToLaunch = false; // Disables the missile bay
            Vector3 missileBay1Position = transform.Find("MissileBay1").position; // Gets the position of missile bay 1
            Vector3 missileBay2Position = transform.Find("MissileBay2").position; // Gets the position of missile bay 2
            Quaternion planeRotation = transform.rotation; // Gets the rotation of the plane
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
            missileBayAudio.PlayOneShot(missileLaunchSound, 1.0f); // Plays the missile launch sound when missile is spawned in

            StartCoroutine(LaunchRateHandler()); // Starts the coroutine to control launch rate
            yield return null; // Ends the coroutine
        }
    }

    // Handles the rate at which missiles are launched
    IEnumerator LaunchRateHandler()
    {
        float timeBeforeNextLaunch = 1 / launchRate; // Value for the time between launches
        yield return new WaitForSeconds(timeBeforeNextLaunch); // Begins the timer
        readyToLaunch = true; // Allows plane to fire the next missile
    }
}
