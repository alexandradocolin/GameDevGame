using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //instead of making the center object ignore every object collision but the players,
        //how about making the ball only ignore the collision with the center object;
        //it's not as if anything else is going to be in the scene anyway
        /*GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
            if (go.activeInHierarchy)
                if (go.GetComponent<Collider>())
                    Physics.IgnoreCollision(go.GetComponent<Collider>(), transform.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(GameObject.Find("Floor").GetComponent<Collider>(), transform.GetComponent<Collider>(), false);
        var player1 = GameObject.Find("Player 1");
        var player2 = GameObject.Find("Player 2");
        if (player1)
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), player1.transform.GetComponent<Collider>(), false);
        if (player2)
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), player2.transform.GetComponent<Collider>(), false);*/
        Physics.IgnoreCollision(GameObject.Find("Cube").GetComponent<Collider>(), transform.GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
