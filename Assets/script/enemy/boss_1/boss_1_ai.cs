using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_1_ai : MonoBehaviour {    
    public float AttCD;
    public bool finishAtt; // did the att script finish the attack process?
    public GameObject player; //check if player is alive

    private player_health playerHealth;
    private enemy_fire attack1;
    private ram_attack attack2;
    public float attCD;
    private bool canAtt = true;
	// Use this for initialization
	void Start () {
        attack1 = GetComponent<enemy_fire>();
        attack2 = GetComponent<ram_attack>();
        attack1.isBoss = true;
        attCD = AttCD;
        attack1.enabled = false;
        attack2.enabled = false;
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
                print("random value is " + random);
                if (random >= 0.5)
                {
                    print("choosing att2");
                    attack2.enabled = true;
                }
                else
                {
                    print("choosing att1");
                    attack1.enabled = true;
                }
                canAtt = false;
            }

            if (!canAtt && finishAtt)
            {

                //print("script finished att");
                attCD -= Time.deltaTime;
                if (attCD < 0)
                {
                    finishAtt = false;
                    attack2.resetAtt();
                    attack1.resetAtt();
                    attack1.enabled = false;
                    attack2.enabled = false;
                    attCD = AttCD;
                    canAtt = true;
                }
            }
        }

    }
}
