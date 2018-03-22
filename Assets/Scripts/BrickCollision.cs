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
        if (transform.position.z > 0)
        {
            //player 1
            //player1.life.LoseLife
            GameObject player = GameObject.Find("Player 1");
            player.GetComponent<Life>().LoseLife();
        }
        else
        {
            //player 2
            //player2.life.LoseLife
            GameObject player = GameObject.Find("Player 2");
            player.GetComponent<Life>().LoseLife();
        }
        //Instantiate(transform, transform.position, Quaternion.identity);
        transform.gameObject.SetActive(false);
        Destroy(transform.gameObject);
    }
}
