using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_trigger : MonoBehaviour {
    private int dmg = 50;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("att triggered " + other.gameObject.tag + " istrigger " + other.isTrigger);
        if (other.tag == "enemies")
        {
            print("about to call other object dmg");
            other.SendMessageUpwards("damage", dmg);
        }
    }
}
