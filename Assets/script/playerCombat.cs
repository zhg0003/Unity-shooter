using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour {

    private bool attack;
    private float timer;
    private float attCD;
    public float maxAttCD = 0.5f;
    private Animator anim;
    public GameObject bullet;
    public float offset = 0.1f;
    // Use this for initialization
    void Awake () {
        attack = false;
        attCD = maxAttCD;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && attack == false) //attack when the fire button is pressed own and player is able to attack
        {
            anim.SetBool("att", true);
            //instantiate bullet object
            Vector3 pos = new Vector3(transform.position.x + offset, transform.position.y, 0);
            Instantiate(bullet, pos, transform.rotation);
            attack = true;
            attCD = maxAttCD;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            //print("att detected");
            anim.SetBool("att", false);
        }

        attCD -= Time.deltaTime;
        if (attCD < 0)
        {
            attack = false;
        }
    }
}
