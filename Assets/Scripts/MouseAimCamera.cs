// Tutorials used in this script:
// https://gamedevacademy.org/unity-3d-first-and-third-person-view-tutorial/#Section_2_Third_Person_Perspective
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;

    public GameObject target;
    private float targetDistance;

    public float minTurnAngle = -90f;
    public float maxTurnAngle = 0.0f;
    private float rotX;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        targetDistance = Vector3.Distance(transform.position, target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // Clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // Rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

        // Move the camera position
        transform.position = target.transform.position - (transform.forward * targetDistance);
    }
}
