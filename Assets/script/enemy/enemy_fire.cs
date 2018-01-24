using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fire : MonoBehaviour {
    public float waiting; 
    public GameObject bullet;
    public float offsetX;
    public float offsetY;
    public int Amount; //amount of bullets will be fired
    public float attackCD; //cd between each bullet
    public Quaternion spawnRoatation;
    public bool isBoss; //is the gameObject attached to a boss
    public boss_1_ai boss;

    private float attCD;
    private int fireAmount; //amount of times this enemy is allowed to fire
    private float waitTimer; //initial waiting timer, only apply once before the first attack
	// Use this for initialization
	void Awake () {
        isBoss = false;
        attCD = attackCD;
        fireAmount = Amount;
        waitTimer = waiting;
	}
	
	// Update is called once per frame
	void Update () {
        //when waitTimer reaches 0, enemy start fire process
        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
        }
        //fire once and stop, or can fire multiple times
        if (waitTimer < 0  && fireAmount > 0 && attCD < 0 ) {
            Vector3 pos = new Vector3(transform.position.x + offsetX, transform.position.y+offsetY, 0);
            Instantiate(bullet, pos, spawnRoatation);
            fireAmount -= 1;
            attCD = attackCD;
        }

        if(fireAmount > 0 )
        {
            attCD -= Time.deltaTime;
        }

        if(fireAmount == 0 && isBoss)
        {
            boss.finishAtt = true;
        }
        
	}

    public void resetAtt() //reset the attack information, used to execute this attack again by other script
    {
        attCD = attackCD;
        fireAmount = Amount;
        waitTimer = waiting;
    }
}
