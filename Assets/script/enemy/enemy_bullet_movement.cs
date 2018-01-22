using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this movement will target the player

public class enemy_bullet_movement : MonoBehaviour
{
    private Collider2D hit;
    public float speed = 1f;
    public int dmg = 10;
    private float step;
    public float timer = 1f;
    private GameObject player;

    private Transform target;
    private Vector3 direction;
    // Use this for initialization

    void Awake()
    {
        hit = GetComponent<Collider2D>();
        hit.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player");
        direction = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x > 12f)
        {
            //print("bullet out of range, destroy this");
            Destroy(gameObject);
        }
    }

    public void death() //this is called when bullet destroyed by player
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "player")
        {
            collision.SendMessageUpwards("damage", dmg);
            Destroy(gameObject);
        }
    }
}
