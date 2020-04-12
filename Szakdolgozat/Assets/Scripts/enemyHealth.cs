using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    
    public GameObject enemyDeathFX;
    public Slider healthSlider;

    public bool drops;
    public GameObject drop;

    public AudioClip deathSound;
    
    float currentHealth;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        healthSlider.maxValue = enemyMaxHealth;
        healthSlider.value = enemyMaxHealth;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        if (currentHealth <= 0) return;

        healthSlider.gameObject.SetActive(true);

        currentHealth -= damage;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
            makeDead();
    }

    public void makeDead()
    {
        gameObject.GetComponentInChildren<CircleCollider2D>().enabled = false;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        anim.Play("GolemDeath");
        if (drops) Instantiate(drop, transform.position, transform.rotation);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<enemyMovement>().enabled = false;
        DestroyObject(gameObject, 3);
        scoreScript.score++;
    }
}
