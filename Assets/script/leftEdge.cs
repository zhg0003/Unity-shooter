using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftEdge : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessageUpwards("death");
    }
}
