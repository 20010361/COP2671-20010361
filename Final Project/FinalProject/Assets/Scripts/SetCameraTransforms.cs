using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraTransforms : MonoBehaviour
{
    // Class variables for setting the camera's positon, rotation, scale
    private Vector3 cameraPositon = new Vector3(0, 35, 0);
    private Vector3 cameraRotation = new Vector3(90, 0, 0);
    private Vector3 cameraScale = new Vector3(1, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        SetUpCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sets up the camera
    void SetUpCamera()
    {
        // Sets the camera's position, rotation, and scale
        transform.position = cameraPositon;
        transform.Rotate(cameraRotation);
        transform.localScale = cameraScale;
    }
}
