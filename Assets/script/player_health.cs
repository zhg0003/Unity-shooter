using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour {
    public int currentHealth;
    public int maxHealth;
    public Slider healthBar;

    private float iframe;
    public float maxIframe;

    public Animator anim;
    public SpriteRenderer sprite;

    public GameObject gameOverMenu; //activate this when player has died
    // Use this for initialization
    void Awake () {
        gameOverMenu.SetActive(false);
        currentHealth = maxHealth;
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
        else if(iframe < 0)
        {
            sprite.enabled = true;
        }
        if (currentHealth == 0)
        {
            death();
        }
	}

    public void death()
    {
        GetComponent<Collider2D>().enabled = false;
        anim.SetBool("death", true);
        gameOverMenu.SetActive(true);
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }

    public void damage(int dmg)
    {
        if (iframe <= 0)//iframe less than 0 means can be damaged
        {
            //anim.Play("hurt");
            if (dmg < currentHealth)
                currentHealth -= dmg;
            else
            {
                currentHealth = 0;
                death();
            }
            iframe = maxIframe;
            healthBar.value = (float)currentHealth / maxHealth;
        }
        
    }
    public void heal(int value)
    {
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
