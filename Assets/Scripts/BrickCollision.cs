using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        //Instantiate(transform, transform.position, Quaternion.identity);
        transform.gameObject.SetActive(false);
        Destroy(transform.gameObject);
    }
}
