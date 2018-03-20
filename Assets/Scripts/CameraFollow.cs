using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    GameObject tmp;
    Rigidbody bottom;

    void Start()
    {
        player.AddComponent<PlayerMovement>();
        player.AddComponent<Camera>();
        bottom = player.GetComponent<Rigidbody>().GetComponent<Rigidbody>();
        bottom.mass = 30;
    }
    
    void Update()
    {

    }
}
