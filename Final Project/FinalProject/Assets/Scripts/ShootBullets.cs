using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootBullets : MonoBehaviour
{
    private GameObject parentObject; // Object the script is the child of
    private Vector3 gunPosition; // The position of the gun for the bullets to spawn from
    private Quaternion planeRotation; // The rotation of the plane for the bullets to face the same direction as the plane

    public GameObject bulletPrefab; // Bullet that will be spawned
    

    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.transform.root.gameObject; // Gets the object the script is child of
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Shoots the plane's main gun
    public void FireGun()
    {
        gunPosition = parentObject.transform.Find("BulletSpawnPosition").position; // Gets the position for bullet to spawn from
        planeRotation = parentObject.transform.rotation; // Gets the direction for bullet to face
        Instantiate(bulletPrefab, gunPosition, planeRotation); // Spawns bullet
    }
}
