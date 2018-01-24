using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_trigger : bullet {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemies" || other.tag == "missile" || other.tag == "boss")
        {
            other.SendMessageUpwards("damage", dmg);
            Destroy(gameObject);
        }
    }
}
