using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_manager : MonoBehaviour {

    public GameObject enemies;
    public float speed = 0.5f;
    public float spawnCD = 3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnCD > 0)
            spawnCD -= Time.deltaTime;
        else
        {
            Vector3 pos = new Vector3(6f, Random.Range(-2f, 2f), 0);
            Instantiate(enemies, pos, transform.rotation);
            spawnCD = 3f;
        }
        //movement(-Time.deltaTime * speed, 0f);
    }

    //protected virtual void movement(float deltaX, float deltaY)
    //{

    //}
}
