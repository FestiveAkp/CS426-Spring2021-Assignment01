// Tutorials used in this script:
// https://code.tutsplus.com/tutorials/unity3d-third-person-cameras--mobile-11230
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10;
    public float rotationSpeed = 60;
    public float jumpForce = 700f;
    public bool isGrounded = true;

    Rigidbody rb;
    Transform t;

    public GameObject cannon;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(t.up * jumpForce);
        }

        // https://docs.unity3d.com/ScriptReference/Input.html
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 2;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1500);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
