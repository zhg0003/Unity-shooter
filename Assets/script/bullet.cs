using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    private Collider2D hit;
    public float speed = 1f;
    public int dmg = 5;
    // Use this for initialization

    void Awake () {
        hit = GetComponent<Collider2D>();
        hit.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        //move the bullet to the right, destroy when out of certain range

        Vector2 pos = new Vector2(transform.position.x + Time.deltaTime*speed, transform.position.y);
        transform.position = pos;
        if(transform.position.x > 12f)
        {
            //print("bullet out of range, destroy this");
            Destroy(gameObject);
        }
    }
}
