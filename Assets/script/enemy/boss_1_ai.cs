using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_1_ai : MonoBehaviour {    
    public float AttCD;
    public bool finishAtt; // did the att script finish the attack process?
    public GameObject player; //check if player is alive

    private player_health playerHealth;
    private enemy_fire phase1;
    private float attCD;
    private bool canAtt = true;
	// Use this for initialization
	void Start () {
        phase1 = GetComponent<enemy_fire>();
        phase1.isBoss = true;
        attCD = AttCD;
        phase1.enabled = false;
        finishAtt = false;
        playerHealth = player.GetComponent<player_health>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth.isAlive)
        {
            if (canAtt)
            {
                phase1.enabled = true;
                canAtt = false;
            }

            if (!canAtt && finishAtt)
            {
                //print("script finished att");
                attCD -= Time.deltaTime;
                if (attCD < 0)
                {
                    phase1.resetAtt();
                    attCD = AttCD;
                    canAtt = true;
                }
            }
        }

    }
}
