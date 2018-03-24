using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FillWallsWithCubes : NetworkBehaviour
{
    public GameObject brick;
    float timer = 0.0f;
    public float wall_height = 30f;
    public float wall_length = 200f;

    // Use this for initialization
    void Start()
    {
        if( brick == null || brick.GetComponent<Renderer>() == null )
        {
            Debug.LogError( "Brick prefab is null or it doesn't have a renderer component attached" );
            return;
        }
        if( isServer )
        {
            InitializeBricks();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if( isServer )
        {
            UpdateBricks();
        }
    }


    void InitializeBricks()
    {
        float brick_height = brick.GetComponent<Renderer>().bounds.size.y;
        float brick_width = brick.GetComponent<Renderer>().bounds.size.y;

        for( float x = 0; x <= wall_length / 2 - brick_width; x += brick_width )
        {
            for( float y = brick_height / 2; y <= wall_height - brick_height / 2; y += brick_height )
            {
                foreach( float x_pos in new float[] { x + brick_width / 2, -x - brick_width / 2 } )
                {
                    GameObject this_brick = Instantiate( brick, new Vector3( x_pos, y, 0 ), Quaternion.identity );
                    this_brick.transform.SetParent( this.transform, false );
                    /*
                    Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
                    Renderer onj = this_brick.GetComponent<MeshRenderer>();
                    float emission = Mathf.PingPong(Time.time, 1.0f);
                    Color finalColor = newColor * Mathf.LinearToGammaSpace(emission);
                    onj.material.color = finalColor;
                     */

                    NetworkServer.Spawn( this_brick );
                }
            }
        }
    }

    [ClientRpc]
    void RpcUpdateBrick( GameObject go, Color new_color )
    {
        if( go == null )
        {
            Debug.Log( "NULLLLL" );
        }
        else
        {
            go.GetComponent<MeshRenderer>().material.color = new_color;
        }

    }

    void UpdateBricks()
    {
        timer += Time.deltaTime;
        if( timer >= 0.2f )
        {
            for( int i = 0; i < transform.childCount; i++ )
            {
                Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
                float emission = Mathf.PingPong( Time.time, 1.5f );
                Color finalColor = newColor * Mathf.LinearToGammaSpace( emission );
                //transform.GetChild(i).GetComponent<MeshRenderer>().material.color = finalColor;
                RpcUpdateBrick( transform.GetChild( i ).gameObject, finalColor );
            }
            timer = 0;
        }
    }
}
