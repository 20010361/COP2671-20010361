using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectTransforms : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Checks if object is tagged as the player
        if(this.gameObject.CompareTag("Player"))
        {
            SetUpPlayerTransforms();
        }
        // Checks if object is tagged as the main camera
        if(this.gameObject.CompareTag("MainCamera"))
        {
            SetUpCameraTransforms();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sets all the transforms of the player object
    void SetUpPlayerTransforms()
    {
        transform.position = new Vector3(0, 1, 0);
        transform.Rotate(new Vector3(0, 0, 0));
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Sets all the transforms for the camera
    void SetUpCameraTransforms()
    {
        transform.position = new Vector3(0, 35, 0);
        transform.Rotate(new Vector3(90, 0, 0));
        transform.localScale = new Vector3(1, 1, 1);
    }
}
