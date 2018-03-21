using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWallsWithCubes : MonoBehaviour {
    public Transform brick;
    public float timer = 0.0f;

    // Use this for initialization
    void Start () {
        float y = transform.localPosition.y;
        float z = transform.localPosition.z;
        Vector3 rot = transform.localEulerAngles;
        if (rot.y == 0)
        {
            for (int y1 = 0; y1 < 4; y1++)
            {
                float x = transform.position.x;
                for (int x1 = 0; x1 < 13; x1++)
                {
                    Instantiate(brick, new Vector3(x, y, z), Quaternion.identity, transform);
                    Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
                    Renderer onj = transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>();
                    if(transform.GetChild(transform.childCount - 1).gameObject.AddComponent<BrickCollision>()) { Debug.Log("da ba"); }
                    float emission = Mathf.PingPong(Time.time, 1.0f);
                    Color finalColor = newColor * Mathf.LinearToGammaSpace(emission);
                    onj.material.color = finalColor;
                    x += 15.0f;
                }
                y += 15.0f;
            }
        }
        
        if (rot.y == 180)
        {
            for (int y1 = 0; y1 < 4; y1++)
            {
                float x = transform.position.x;
                for (int x1 = 0; x1 < 13; x1++)
                {
                    Instantiate(brick, new Vector3(x, y, z), Quaternion.identity, transform);
                    Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
                    Renderer onj = transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>();
                    if (transform.GetChild(transform.childCount - 1).gameObject.AddComponent<BrickCollision>()) { Debug.Log("da ba"); }
                    float emission = Mathf.PingPong(Time.time, 1.0f);
                    Color finalColor = newColor * Mathf.LinearToGammaSpace(emission);
                    onj.material.color = finalColor;
                    x -= 15.0f;
                }
                y += 15.0f;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            for (int i =0; i < transform.childCount; i++)
            {
                Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
                float emission = Mathf.PingPong(Time.time, 1.5f);
                Color finalColor = newColor * Mathf.LinearToGammaSpace(emission);
                transform.GetChild(i).GetComponent<MeshRenderer>().material.color = finalColor;
            }
            timer = 0;
        }
	}
}
