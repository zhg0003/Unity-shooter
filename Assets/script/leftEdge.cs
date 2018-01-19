using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftEdge : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("att triggered " + other.gameObject.tag + " istrigger " + other.isTrigger);
        print("about to call other object dmg");
        other.SendMessageUpwards("death");
    }
}
