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
    
    void FixedUpdate ()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (!Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotation_coef);
        }
        /*Vector3 pos = rb.position;
        int minX = 0, maxX = 0, minY = 0, maxY = 0, minZ = 0, maxZ = 0;
        if (rb.name == "Player 1") { minX = -300; maxX = 300; minY = -300; maxY = 300; minZ = 0; maxZ = 300; }
        else { minX = -300; maxX = 300; minY = -300; maxY = 300; minZ = 0; maxZ = -300; }
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        rb.position = pos;*/
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
