using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    public GameObject bloodFX;
    public AudioClip playerHurt;

    public GameObject gameOverScreen;

    float currentHealth;

    //PlayerController controlMovement;

    //HUD variables
    public Slider healthSlider;
    public Image damageScreen;

    bool damaged = false;
    Color damagedColor = new Color(255f, 0f, 0f, 0.5f);
    float smoothColor = 5f;

    Animator anim;
    AudioSource playerAS;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //controlMovement = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();

        //HUD Initialization
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
            damageScreen.color = damagedColor;
        else
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        damaged = false;
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        if (currentHealth <= 0) return;
        currentHealth -= damage;

        playerAS.PlayOneShot(playerHurt);

        healthSlider.value = currentHealth;
        damaged = true;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(bloodFX, transform.position, transform.rotation);
        anim.Play("ReaperDeath");
        gameOverScreen.SetActive(true);
        GameObject.Find("PlayerAttackRange").SetActive(false);
        gameObject.GetComponent<PlayerController>().enabled = false;
    }
}
