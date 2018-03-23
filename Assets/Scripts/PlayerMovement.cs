using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {
    Rigidbody rb;
    public float rotation_coef = 300f;
    public float move_coef = 1500f;
    public GameObject cameraPrefab;

	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(Vector3.zero);
        rb.angularVelocity = Vector3.zero;
        if (GameObject.Find("Player 1"))
        {
            transform.gameObject.name = "Player 2";
        }
        else
        {
            transform.gameObject.name = "Player 1";
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        GameObject go = Instantiate(cameraPrefab, new Vector3(-20, 6, 0), Quaternion.Euler(0, 0, 20)) as GameObject;
        go.transform.SetParent(this.transform, false);
    }
    
    void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (!Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotation_coef);
        }
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * Time.deltaTime * 20f);
        Vector3 v3 = transform.InverseTransformDirection(rb.velocity);
        //Vector3 v3 = rb.velocity;
        v3.x = -Input.GetAxis("Vertical") * Time.deltaTime * move_coef;
        v3.z = Input.GetAxis("Horizontal") * Time.deltaTime * move_coef;
        //rb.velocity.x = Input.GetAxis("Horizontal") * Time.deltaTime * 20;
        rb.velocity = transform.TransformDirection(v3);
        //Debug.Log(rb.velocity.z + "pressed");
    }
}
