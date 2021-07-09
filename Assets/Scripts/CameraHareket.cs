using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHareket : MonoBehaviour
{
    Camera cam;
    public float leftConstraint;
    public float rightConstraint;
    public float distanceZ = 10.0f;
    
    void Start()
    {
    
        
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
    }

    void FixedUpdate()
    {
        if (transform.position.x < leftConstraint)
        {
            transform.position = new Vector3(rightConstraint, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightConstraint)
        {
            transform.position = new Vector3(leftConstraint, transform.position.y, transform.position.z);
        }
    }
}
