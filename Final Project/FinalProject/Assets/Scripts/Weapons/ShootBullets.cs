using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootBullets : MonoBehaviour
{
    private bool readyToFire = true; // Determines whether the gun can fire
    private AudioSource mainGunAudio; // The component that plays the gun shot sounds

    public GameObject bulletPrefab; // Bullet that will be spawned
    public float rateOfFire = 2; // The rate at which the bullets are shot
    public AudioClip gunShotSound; // The sound of the gun firing


    // Start is called before the first frame update
    void Start()
    {
        mainGunAudio = GetComponent<AudioSource>(); // Gets the audio source component on the parent object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Shoots the plane's main gun
    public IEnumerator FireGun()
    {
        // Executes if the gun is ready to fire
        if(readyToFire == true)
        {
            readyToFire = false; // Disables the gun
            Vector3 gunPosition = transform.Find("BulletSpawnPosition").position; // Gets the position for bullet to spawn from
            Quaternion planeRotation = transform.rotation; // Gets the direction for bullet to face
            Instantiate(bulletPrefab, gunPosition, planeRotation); // Spawns bullet
            mainGunAudio.PlayOneShot(gunShotSound, 1.0f); // Plays the gun shot when bullet is spawned in

            StartCoroutine(FireRateHandler()); // Starts a coroutine to handle time between shots
            yield return null; // Ends the coroutine
        }      
    }

    // Handles the time between shots
    IEnumerator FireRateHandler()
    {
        float timeBeforeNextShot = 1 / rateOfFire; // Value for the time between shots
        yield return new WaitForSeconds(timeBeforeNextShot); // Begins the timer
        readyToFire = true; // Enables the gun
    }
}
