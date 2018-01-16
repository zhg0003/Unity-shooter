using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmanager : MonoBehaviour {
    public GameObject[] bg = new GameObject[3];
    public float end = -18.9f;
    public Vector2 begin = new Vector2(36.05f, 0.035f);
    public Queue<GameObject> background; //THIS THING WON'T WORK WHYYY I DON'T WANNA USE LOOP D=
	// Use this for initialization
	void Start ()
    {
        //bg[0] = GameObject.FindGameObjectWithTag("");
        //begin.x = 2*(bg[1].transform.position.x - bg[2].transform.position.x);

    }

	// Update is called once per frame
	void Update () {
        for(int i = 0; i < 3; i++)
        {
            print((Vector2)bg[i].transform.position);
            if (bg[i].transform.position.x <= end)
            {              
                bg[i].transform.position = begin;
            }
        }
	}
}
