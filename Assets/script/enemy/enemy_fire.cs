using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fire : MonoBehaviour {

    public float waiting;
    public GameObject bullet;
    public float offset = 0.1f;
    public int Amount; //amount of bullets will be fired
    public float attackCD;

    private float attCD;
    private int fireAmount; //amount of times this enemy is allowed to fire
    private float waitTimer; //initial waiting timer, only apply once before the first attack
    private bool canFire;
	// Use this for initialization
	void Awake () {
        attCD = attackCD;
        fireAmount = Amount;
        waitTimer = waiting;
        canFire = false;
	}
	
	// Update is called once per frame
	void Update () {
        //when waitTimer reaches 0, enemy can fire
        if (waitTimer > 0 && canFire == false)
        {
            waitTimer -= Time.deltaTime;
        }

        //fire once and stop, or can fire multiple times
        if (waitTimer < 0  && fireAmount > 0 && attackCD < 0 ) {
            Vector3 pos = new Vector3(transform.position.x + offset, transform.position.y, 0);
            Instantiate(bullet, pos, transform.rotation);
            fireAmount -= 1;
            attackCD = attCD;
        }

        if(fireAmount > 0 )
        {
            attackCD -= Time.deltaTime;
        }

	}
}
