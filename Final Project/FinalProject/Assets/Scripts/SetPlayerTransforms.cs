using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class may be removed and all functionality will be moved to the game manager class
public class SetPlayerTransforms : MonoBehaviour
{
    // Variables for setting the player's postion, rotation, scale
    private Vector3 playerPosition = new Vector3(0, 1, 0);
    private Vector3 playerRotation = new Vector3(0, 0, 0);
    private Vector3 playerScale = new Vector3 (1, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        SetUpPlayerTransfroms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sets up the player transforms
    void SetUpPlayerTransfroms()
    {
        // Sets the player's postion, rotation, and scale
        transform.position = playerPosition;
        transform.Rotate (playerRotation);
        transform.localScale = playerScale;
    }
}
