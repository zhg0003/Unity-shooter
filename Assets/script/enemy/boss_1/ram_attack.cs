using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ram_attack : MonoBehaviour {
    public GameObject player; 
    public float speedY; //default positive
    public float windUpTime; //time spend performing windup
    public float speedX; //default positive
    public float chargeSpeed; //default negative
    public float chargeRecover; //recover time after charge before boss can perform next action
    public Vector3 init; //initial position
    public boss_1_ai boss;

    private float CR;
    private float WUT;
    private Transform playerPos;
    private bool canAttack; //can this attack be performed
    private float step;
    private bool readyCharge; //ready to charge at player
    private bool readyRecover; //ready to go back to initial position after charge
	// Use this for initialization
	void Awake () {
        canAttack = true;
        readyCharge = false;
        readyRecover = false;
        playerPos = player.transform;
        WUT = windUpTime;
        CR = chargeRecover;
	}
	
	// Update is called once per frame
	void Update () {
        if (canAttack == true)
        {
            //track the player's Y position
            //calculate going up or down
            //move
            if (!readyCharge)
            {
                //play visual que, keep tracking
                if (trackingPlayer())
                    readyCharge = windUp();
            }
            else
            {
                //attack, stop tracking
                if (!readyRecover)
                {
                    readyRecover = charge();
                }
                else
                {
                    //return to initial position, last phase of this attack, set canAttack to false once this phase complete
                    canAttack = returnToInit();
                }
            }
        }
        else
            boss.finishAtt = true; //tell the boss ai script this attack process is finished
    }

    public void resetAtt() //reset speed  and canAttack
    {
        print("reseting");
        canAttack = true;
        readyCharge = false;
        readyRecover = false;
        speedY = 4.5f;
        CR = chargeRecover;
        WUT = windUpTime;
    }

    private bool returnToInit()
    {
        if (Mathf.Abs(transform.position.x - init.x) > 0.25)
        {
            Vector3 direction = (transform.position - init).normalized;
            transform.position += direction * chargeSpeed * Time.deltaTime;
            return true;
        }
        return false;
    }

    private bool trackingPlayer()
    {
        if (Mathf.Abs(transform.position.y - playerPos.position.y) <= 0.3)
        {
            speedY = 4;
            return true;
        }
        else
        {
            playerPos = player.transform;
            if (playerPos.position.y < transform.position.y) //player is lower than boss, flip speedY
            {
                step = -speedY * Time.deltaTime;
            }
            else
                step = speedY * Time.deltaTime;
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + step);
            transform.position = pos;
            return false;
        }
    }

    private bool windUp()
    {
        if (WUT > 0)
        {
            WUT -= Time.deltaTime;
            transform.position = new Vector2(transform.position.x + speedX * Time.deltaTime, transform.position.y);
        }
        return WUT <= 0 ;
    }

    private bool charge()
    {
        //stop charging when reach player's x position
        if (Mathf.Abs(transform.position.x + 6) > 0.25)
        {
            transform.position = new Vector2(transform.position.x + chargeSpeed * Time.deltaTime, transform.position.y);
        }
        if(CR > 0)
        {
            CR -= Time.deltaTime;
        }
        return CR <= 0;
    }
}
