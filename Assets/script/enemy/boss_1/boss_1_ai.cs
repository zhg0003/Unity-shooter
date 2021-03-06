﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_1_ai : MonoBehaviour {    
    public float AttCD;
    public bool finishAtt; // did the att script finish the attack process?
    public GameObject player; //check if player is alive
    public int impactDMG;

    private player_health playerHealth;

    private enemy_fire attack1;
    private ram_attack attack2;
    private spawnTimeBomb attack3;

    private float attCD;
    private bool canAtt = true;
	// Use this for initialization
	void Start () {
        attack1 = GetComponent<enemy_fire>();
        attack2 = GetComponent<ram_attack>();
        attack3 = GetComponent<spawnTimeBomb>();
        attack1.isBoss = true;
        attCD = AttCD;
        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
        finishAtt = false;
        playerHealth = player.GetComponent<player_health>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth.isAlive)
        {
            if (canAtt)
            {
                float random = Random.value;
                print((float)2 / 3);
                if (random > (float)2/3)
                {
                    attack2.enabled = true;
                }
                else if (random > (float)1/3)
                {
                    attack1.enabled = true;
                }
                else
                {
                    attack3.enabled = true;
                }
                canAtt = false;
            }

            if (!canAtt && finishAtt)
            {

                //print("script finished att");
                attCD -= Time.deltaTime;
                if (attCD < 0)
                {
                    resetAtt();
                    finishAtt = false;
                    attCD = AttCD;
                    canAtt = true;
                }
            }
        }
    }

    private void resetAtt()
    {
        attack1.resetAtt();
        attack2.resetAtt();
        attack3.resetAtt();
        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.SendMessageUpwards("damage", impactDMG);
        }
        if(other.tag == "bullet")
        {
        }
    }
}
