using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement_straight : enemy_group_manager
{
    // Use this for initialization
    public float speedx;
    public float speedy;
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement(-Time.deltaTime * speedx, Time.deltaTime * speedy);
    }
    private void movement(float deltaX, float deltaY)
    {
        Vector2 pos = new Vector2(transform.position.x + deltaX, transform.position.y + deltaY);//Mathf.Cos(deltaY*initY)
        transform.position = pos;
    }
}