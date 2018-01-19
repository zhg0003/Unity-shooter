using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    public int maxHealth;
    public Slider healthBar;
    private float iframe;
    public float maxIframe;
    public Animator anim;
    public SpriteRenderer sprite;

    // Use this for initialization
    void Awake () {
        maxHealth = 100;
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        healthBar.value = currentHealth / maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (iframe > 0)
        {
            sprite.enabled = !sprite.enabled;
            iframe -= Time.deltaTime;
        }
        if (currentHealth == 0)
        {
            death();
        }
	}

    public void death()
    {
        print("dead");
        anim.SetBool("death", true);
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }

    public void damage(int dmg)
    {
        print("damage called, incoming dmg "+dmg);
        if (iframe <= 0)//iframe less than 0 means can be damaged
        {
            //anim.Play("hurt");
            currentHealth -= dmg;
            iframe = maxIframe;
            healthBar.value = (float)currentHealth / maxHealth;
        }
        
    }
    public void heal(int value)
    {
        print("heal is called");
        if (currentHealth <= 0)
        {
            print("player is dead lulz");
        }
        else
        {
            currentHealth += value;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
            healthBar.value = (float)currentHealth / maxHealth;
        }
    }
}
