using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public float speed = 1f;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //start with moving right 
        if (Input.GetKey("right"))
        {
            movement(Time.deltaTime * speed, 0f);
        }
        if (Input.GetKey("left"))
        {
            movement(-Time.deltaTime * speed, 0f);
        }

        if (Input.GetKey("up"))
        {
            movement(0f, Time.deltaTime * speed);
        }

        if (Input.GetKey("down"))
        {
            movement(0f, -Time.deltaTime * speed);
        }
    }

    private void movement(float deltaX, float deltaY)
    {
        //print("current transform position is " + transform.position);
        Vector2 pos = new Vector2(transform.position.x + deltaX, transform.position.y+deltaY);
        transform.position = pos;
        //print("moving to position" + pos);
    }
}
