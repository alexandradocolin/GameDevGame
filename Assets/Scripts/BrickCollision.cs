using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BrickCollision : NetworkBehaviour
{
    public string permitted_collider_tag;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        //Destroy cube only if the ball has touched it
        //if (other.collider.gameObject.CompareTag(permitted_collider_tag))
        {
            try
            {
                if (transform.position.z < 0)
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
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            //Instantiate(transform, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
