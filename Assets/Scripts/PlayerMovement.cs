using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {
    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(Vector3.zero);
        rb.angularVelocity = Vector3.zero;
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    
    void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if( !Input.GetMouseButton( 1 ) )
        {
            transform.Rotate( new Vector3( 0, Input.GetAxis( "Mouse X" ), 0 ) * Time.deltaTime * 150f );
        }
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * Time.deltaTime * 20f);
        Vector3 v3 = transform.InverseTransformDirection( rb.velocity );
        //Vector3 v3 = rb.velocity;
        v3.x = -Input.GetAxis( "Vertical" ) * Time.deltaTime * 1500;
        v3.z = Input.GetAxis( "Horizontal" ) * Time.deltaTime * 1500;
        //rb.velocity.x = Input.GetAxis("Horizontal") * Time.deltaTime * 20;
        rb.velocity = transform.TransformDirection( v3 );
        //Debug.Log(rb.velocity.z + "pressed");
    }
}
