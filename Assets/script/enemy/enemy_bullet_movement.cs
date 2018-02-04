using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this movement will target the player

public class enemy_bullet_movement : MonoBehaviour
{
    public ParticleSystem explosion;
    public float speed = 1f;
    public int dmg = 10;
    
    public float timer = 1f;
    private GameObject player;
    private Collider2D hit;
    private Transform target;
    private Vector3 direction;
    private float step;
    // Use this for initialization

    void Awake()
    {
        hit = GetComponent<Collider2D>();
        hit.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player!=null)
        {
            direction = (player.transform.position - transform.position).normalized;
        }
        else
        {
            direction = new Vector3(-1, transform.position.y, 0).normalized;
        }
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
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }
}
