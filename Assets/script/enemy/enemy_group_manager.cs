using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_group_manager : MonoBehaviour {

    public GameObject enemies;
    public float maxSpawnCD = 3f;
    public float groupCD;
    public int amount; //spawn amount
    public Vector3 pos; //spawn position

    private Vector3 spawnPos;
    private float spawnCD;
    private float groupSpawnCD;
    private int spawnAmount;
    private bool canSpawn;

    // Use this for initialization
    void Start () {
        spawnAmount = amount;
        spawnCD = maxSpawnCD;
        groupSpawnCD = groupCD;
        spawnPos = pos;
        canSpawn = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (canSpawn) 
        {
            spawn();
        }
        //groupCD should start decreasing when one group has finished spawning
        if (spawnAmount == 0)
        {
            canSpawn = false;
            groupSpawnCD -= Time.deltaTime;
        }

        if(groupSpawnCD < 0) //once group cd reaches 0, reset spawn info
        {
            spawnAmount = amount;
            groupSpawnCD = groupCD;
            canSpawn = true;
            spawnPos = new Vector3(6f, Random.Range(-3f,3f), 0);
        }

    }

    private void spawn()
    {
        if (spawnCD > 0)
            spawnCD -= Time.deltaTime;
        else if (spawnAmount > 0)
        {
            Instantiate(enemies, spawnPos, transform.rotation);
            spawnCD = maxSpawnCD;
            spawnAmount -= 1;
        }
    }
    //protected virtual void movement(float deltaX, float deltaY)
    //{

    //}
}
