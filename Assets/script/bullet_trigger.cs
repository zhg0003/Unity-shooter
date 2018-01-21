using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_trigger : bullet {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemies")
        {
            print("calling dmg on enemy");
            other.SendMessageUpwards("damage", dmg);
            Destroy(gameObject);
        }
    }
}
