using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this attack will move to an initial position, move up and down while spawning timebombs
public class spawnTimeBomb : MonoBehaviour {
    public GameObject boss;
    public GameObject timeBomb;
    public float offsetX1;
    public float offsetY1;
    public float offsetX2;
    public float offsetY2;
    public float spawnCD;
    public Vector3 initPos; //pos which boss starts spawning bombs
    public int numTurns; //number of turns the movement should make
    public float speed;

    private int nt;
    private Vector3 startPos = new Vector3(4.5f, 0f, 0f); //pos which this att started
    private bool canAtt = false;
    private bool down = true; //are we moving down
    private float spawncd;
    private bool inPos; //has this boss arrive to the initial position
    private Vector3 direction; //direction from the current position to the initial position

	// Use this for initialization
	void Awake () {
        inPos = false;
        spawncd = spawnCD;
        nt = numTurns;
	}
	
	// Update is called once per frame
	void Update () {
        if (!inPos)
        {
            direction = (initPos - transform.position).normalized;
            moveTo(initPos);
        }
        else if(nt > 0) //boss is in position
        {
            movement();
            if (spawncd < 0 && canAtt)
            {
                Vector3 pos = new Vector3(transform.position.x + offsetX1, transform.position.y + offsetY1, 0);
                Instantiate(timeBomb, pos, transform.rotation);
                spawncd = spawnCD;
            }
            spawncd -= Time.deltaTime;
        }
        else if(canAtt == true)
        {
            direction = (startPos - transform.position).normalized;
            moveTo(startPos);
            if (Mathf.Abs(transform.position.x - startPos.x) <= 0.1 && Mathf.Abs(transform.position.y - startPos.y) <= 0.1)
            {
                canAtt = false;
                boss.GetComponent<boss_1_ai>().finishAtt = true;
            }
        }
    }

    private void moveTo(Vector3 pos)
    {
        transform.position += direction * speed * Time.deltaTime;
        if(Mathf.Abs(transform.position.x - initPos.x) <= 0.1 && Mathf.Abs(transform.position.y - initPos.y) <= 0.1)
        {
            inPos = true;
            canAtt = true;
        }
    }

    private void movement()
    {
        //move down
        if (down)
        {
            Vector3 pos = new Vector3(4f, transform.position.y-speed*Time.deltaTime, 0);
            transform.position = pos;
            if(transform.position.y <= -2)
            {
                down = !down;
                nt -= 1;
            }
        }
        else
        {
            Vector3 pos = new Vector3(4f, transform.position.y + speed * Time.deltaTime, 0);
            transform.position = pos;
            if (transform.position.y >= 2)
            {
                down = !down;
                nt -= 1;
            }
        }
    }

    public void resetAtt()
    {
        down = true;
        canAtt = false;
        inPos = false;
        spawncd = spawnCD;
        nt = numTurns;
    }
}
