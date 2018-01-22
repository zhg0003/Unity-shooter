using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this movement will rise then target, similiar to movement 1

public class enemy_bullet_movement_2 : MonoBehaviour
{
    public float speedy = 1f;
    public int dmg = 10;
    public float timer = 1f;
    public float AccY;
    public float AccX;
    //public float yDis;
    public float rotationSpeed;

    private Animator anim;
    private float ay;
    private float ax;
    private Collider2D hit;
    private GameObject player;
    private bool moveY = true; //moving in Y direction initially, 
    private bool target = false; // rotaional movement that target the player, false means it has not been completed yet
    private Vector3 direction;
    private float speedx;
    private Quaternion rotation; //rotation needed to look at target
    // Use this for initialization

    void Awake()
    {
        hit = GetComponent<Collider2D>();
        hit.enabled = true;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        ax = AccX;
        ay = AccY;
        speedx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, direction, Color.red);
        if (moveY == true)
        {

            moveUp();
        }

        else if(target == false)
        {
            direction = (player.transform.position - transform.position).normalized;
            rotate();
        }
        else
        {
            moveTowards();
        }

    }

    private void rotate()
    {
        
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * rotationSpeed);
        if (-0.99f >= Vector3.Dot(transform.right, direction) && Vector3.Dot(transform.right, direction) >= -1.11f)
        {
            target = true;
        }
    }
    private void moveUp()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speedy, 0);
        transform.position = pos;
        speedy = speedy + Time.deltaTime * AccY;
        if(speedy < 0)
        {
            speedy = 0;
            moveY = false;
        }
    }

    private void moveTowards()
    {
        transform.position += direction * speedx * Time.deltaTime;
        speedx += Time.deltaTime * ax;
    }
    public void death() //this is called when bullet is out of range
    {
        ax = 0;
        speedx = 0;
        hit.enabled = false;
        anim.SetBool("death", true);
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            death();
            collision.SendMessageUpwards("damage", dmg);
        }
    }
}
