using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigi : MonoBehaviour {
    public float ballInitialVelocity = 6f;
    private Rigidbody rb;
    private bool ballInPlay;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(6f, 6f, 0));
        }
        /*
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(10, 0, 0);
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            rb.AddForce(movement);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        */
        /*
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(10, 0, 0);
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * -1.0f, 0.0f, 0.0f);
            rb.AddForce(movement);
        }
        if (!Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        */
    }
}
