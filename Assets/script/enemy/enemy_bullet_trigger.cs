using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_trigger :enemy_bullet_movement
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            print("about to call other object dmg");
            other.SendMessageUpwards("damage", dmg);
            Destroy(gameObject);
        }
    }
}
