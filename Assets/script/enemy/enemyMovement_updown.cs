using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement_updown : enemy_group_manager //move up and down based on timer
{
    // Use this for initialization
    public float speedx;
    public float speedy;
    public float timer;

    private float moveTime;
    public Transform currentPos;
    void Awake()
    {
        currentPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveTime < 0)
        {
            moveTime = timer;
            speedy = -speedy;
        }
            
        movement(-Time.deltaTime * speedx, Time.deltaTime * speedy);
        moveTime -= Time.deltaTime;
    }

    private void movement(float deltaX, float deltaY)
    {
        Vector2 pos = new Vector2(transform.position.x + deltaX, transform.position.y + deltaY);//Mathf.Cos(deltaY*initY)
        transform.position = pos;
    }
}