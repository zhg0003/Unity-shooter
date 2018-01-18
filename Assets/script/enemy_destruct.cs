using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destruct : MonoBehaviour {
    public int dmg = 50;
    public Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("att triggered " + other.gameObject.tag + " istrigger " + other.isTrigger);
        if (other.tag == ("Player"))
        {
            print("about to call other object dmg, dmg is "+dmg);
            other.SendMessageUpwards("damage", dmg);
            anim.SetBool("death", true);
            Destroy(gameObject,anim.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
