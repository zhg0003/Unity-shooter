using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeBomb : MonoBehaviour {
    public int dmg;
    public GameObject range;
    public float speed; //speed at which the indicator expands
    public float countDown;
    public float offset; //final scale offset before explosion for accurate animation scale

    private float radius;
    private Animator anim;
    private CircleCollider2D blastRadius;
    private BoxCollider2D hitbox;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        blastRadius = GetComponent<CircleCollider2D>();
        radius = blastRadius.radius;
        blastRadius.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        //increase the indicator scale by speed as time moves on
        if (countDown > 0)
        {
            range.transform.localScale = new Vector3(range.transform.localScale.x + Time.deltaTime * speed, range.transform.localScale.y + Time.deltaTime * speed, 0);
            radius += Time.deltaTime * speed * 0.072f;
            blastRadius.radius = radius;
            //blastRadius.radius += Time.deltaTime * speed * 0.072f;

            //transform.localScale = new Vector3(range.localScale.x + Time.deltaTime * speed, range.localScale.y + Time.deltaTime * speed, range.localScale.z + Time.deltaTime * speed);
            countDown -= Time.deltaTime;
        }
        else
        {
            death();
        }
    }

    public void death()
    {
        transform.localScale = new Vector3(range.transform.localScale.x + offset, range.transform.localScale.y + offset, range.transform.localScale.z + offset);
        range.SetActive(false);
        //blastRadius.radius = 0.26f;
        blastRadius.radius = radius/4.25f;
        blastRadius.enabled = true;
        anim.SetBool("death", true);
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            collision.SendMessageUpwards("damage", dmg);
        }
    }
}
