using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour {
    public float smoothTime = 0.3F;
    public float speed = 1f;
    public float modifier = 1.5f; //modify movement speed
    public float dashDuration = 3f;
    public float dashCD = 3f;
    public SpriteRenderer engineFire; //modify engine fire scale and position when player dash
    public Slider dashBar;

    private float mod;
    private float dash; //the dash duration
    private float dashCd; //CD before next dash
    private bool canDash = true;
    // Use this for initialization
    void Start ()
    {
        dashBar.value = 1;
        mod = 1;
        dash = dashDuration;
        dashCd = dashCD;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canDash) {
            canDash = false;
            dash = dashDuration;
            mod = modifier;
            dash = 1f;
            dashCd = dashCD;
            engineFire.transform.localScale = new Vector3(2.55f, 2.55f, 0);
            engineFire.transform.position = new Vector3(transform.position.x - 0.5141f, transform.position.y - 0.3186f, 0);
        }
        //start with moving right 
        if (Input.GetKey("right"))
        {
            movement(Time.deltaTime * speed * mod, 0f);
        }
        if (Input.GetKey("left"))
        {
            movement(-Time.deltaTime * speed * mod, 0f);
        }

        if (Input.GetKey("up"))
        {
            movement(0f, Time.deltaTime * speed * mod);
        }

        if (Input.GetKey("down"))
        {
            movement(0f, -Time.deltaTime * speed * mod);
        }

        if(dash > 0)
        {
            dash -= Time.deltaTime;
        }

        if(dash < 0) //set speed modifier to 1
        {
            mod = 1;
            engineFire.transform.localScale = new Vector3(1f, 1f, 0);
            engineFire.transform.position = new Vector3(transform.position.x - 0.38f, transform.position.y - 0.1f, 0);
        }

        if(dashCd > 0 && canDash == false)
        {
            dashCd -= Time.deltaTime;
            dashBar.value = (dashCD - dashCd) / dashCD;
            if (dashCd < 0)
            {
                dashCd = 0f;
                canDash = true;
            }
        }
    }

    private void movement(float deltaX, float deltaY)
    {
        //print("current transform position is " + transform.position);
        Vector2 pos = new Vector2(transform.position.x + deltaX, transform.position.y+deltaY);
        transform.position = pos;
        //print("moving to position" + pos);
    }
}
