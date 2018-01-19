using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : enemy_manager
{
    public float smoothTime = 0.3F;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement(-Time.deltaTime * speed, 0f);
    }

    private void movement(float deltaX, float deltaY)
    {
        //print("current transform position is " + transform.position);
        print("moving enemies");
        Vector2 pos = new Vector2(transform.position.x + deltaX, transform.position.y + deltaY);
        transform.position = pos;
        //print("moving to position" + pos);
    }
}