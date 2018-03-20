using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotation_speed = 45f;
    public float max_y_angle = 45f;
    public float max_other_than_y_angle = 30f;
    public float min_other_than_y_angle = -15f;

    Camera cam;
    public GameObject camera_target;

    float y_value;
    float other_than_y_value;
    float zoom_scale = 1f;
    public float min_zoom_scale = 0.1f;
    public float max_zoom_scale = 4f;
    public float zoom_factor = 1.1f;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        y_value = 0f;
        other_than_y_value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float hor_move = -Input.GetAxis( "Mouse X" );
        float vert_move = -Input.GetAxis( "Mouse Y" );

        //RMB is pressed
        if( Input.GetMouseButton( 1 ) )
        {
            float other_than_y_diff = vert_move * rotation_speed * Time.deltaTime;
            float y_diff = -hor_move * rotation_speed * Time.deltaTime;
            
            if( y_value + y_diff >= max_y_angle )
                y_diff = max_y_angle - y_value;
            if( y_value + y_diff <= -max_y_angle )
                y_diff = -max_y_angle - y_value;

            if( other_than_y_value + other_than_y_diff > max_other_than_y_angle )
                other_than_y_diff = max_other_than_y_angle - other_than_y_value;
            if( other_than_y_value + other_than_y_diff < min_other_than_y_angle )
                other_than_y_diff = min_other_than_y_angle - other_than_y_value;

            camera_target.transform.Rotate( other_than_y_diff, 0, 0, Space.Self );
            camera_target.transform.Rotate( Vector3.up, y_diff, Space.World );
            y_value += y_diff;
            other_than_y_value += other_than_y_diff;
        }

        if( Input.mouseScrollDelta.y != 0 )
        {
            if( Input.mouseScrollDelta.y < 0 )
            {
                if( zoom_scale < max_zoom_scale )
                {
                    zoom_scale *= zoom_factor;
                }
            }
            else
                if( zoom_scale > 0.1f )
                {
                    zoom_scale /= zoom_factor;
                }
            camera_target.transform.localScale = new Vector3( 1, 1, zoom_scale );
        }
    }
}
