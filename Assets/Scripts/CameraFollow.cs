using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//some of the commented lines are kept as guides for my degree
public class CameraFollow : MonoBehaviour
{
    //using an offset to measure the distance between the player and me
    //when the offset is 0, the player reflects in the oppsite direction according to some angle
    //the player is going to hit either a cube or some wall at some point
    //if it's a cube, the cube disappears when hit
    //if it's a wall, nothing special happens
    //in both cases though, the player is reflected on the same principle as above
    public GameObject player;
    GameObject tmp;
    Rigidbody bottom;

    //private Vector3 offset;
    //float distance;
    //Vector3 playerPrevPos, playerMoveDir;

    // Use this for initialization
    void Start()
    {
        /*
        tmp = new GameObject();
        tmp.transform.parent = player.transform;
        tmp.transform.localPosition = Vector3.zero;
        tmp.transform.localRotation = Quaternion.identity;
        tmp.transform.localScale = Vector3.one;
        tmp.transform.parent = null;
        tmp.transform.eulerAngles = new Vector3(0, 0, 0);
        */
        /*
        player.transform.parent = tmp.transform;
        tmp.AddComponent<PlayerMovement>();
        */

        player.AddComponent<PlayerMovement>();
        player.AddComponent<Camera>();
        bottom = player.GetComponent<Rigidbody>().GetComponent<Rigidbody>();
        bottom.mass = 30;
        /*
        tmp.AddComponent<Rigidbody>();
        tmp.GetComponent<Rigidbody>().mass = 30;
        tmp.AddComponent<MeshCollider>();
        tmp.GetComponent<MeshCollider>().convex = true;
        */
        //offset = transform.position - player.transform.position;
        //distance = 0;
        //distance = offset.magnitude;
        //playerPrevPos = player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * Time.deltaTime * 20f);
        //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 65f);

        /*
        //camera follows the assigned player
        playerMoveDir = tmp.transform.position - playerPrevPos;
        if (playerMoveDir != Vector3.zero)
        {
            playerMoveDir.Normalize();
            transform.position = tmp.transform.position - playerMoveDir;
            //transform.position = tmp.transform.position - playerMoveDir * distance;
            //Vector3 temp = new Vector3(0, 5f);
            //transform.position += temp; // required height
            transform.LookAt(tmp.transform.position);
            playerPrevPos = tmp.transform.position;
        }
        */
    }
}
