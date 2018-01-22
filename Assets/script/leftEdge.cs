using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftEdge : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "enemies" || other.tag == "bullet" || other.tag == "missile")
        {
            other.SendMessageUpwards("death");
        }
    }
}
