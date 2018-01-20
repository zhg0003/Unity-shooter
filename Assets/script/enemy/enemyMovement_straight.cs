using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement_straight : enemy_group_manager
{
    // Use this for initialization
    public Transform currentPos;
    public float speedx;
    void Awake()
    {
        currentPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        movement(-Time.deltaTime * speedx, 0);
    }
    private void movement(float deltaX, float deltaY)
    {
        Vector2 pos = new Vector2(transform.position.x + deltaX, transform.position.y + deltaY);//Mathf.Cos(deltaY*initY)
        transform.position = pos;
        //if (Mathf.Abs(speedy) < minSpeedY && !maxYDistanceReached)
        //{
        //    print("in here, speed is " + speedy);
        //    maxYDistanceReached = true;
        //}

        //if ((gameObject.transform.position.y >= pos.y - 0.01f && gameObject.transform.position.y <= pos.y + 0.01f) && maxYDistanceReached)
        //{
        //    print("gameobject position y vs pos y " + gameObject.transform.position.y + " " + pos.y);
        //    //print("current speedy is " + speedy);
        //    //accY = -accY;
        //    maxYDistanceReached = false;
        //}
        //speedy = (float)(Time.deltaTime * -accY) + speedy;
    }
}