using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBG : MonoBehaviour {
    public float speed = 0.5f; //smaller the faster

    void Start()
    {

    }
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }

}
