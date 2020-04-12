using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public AudioClip hitSound;

    public float damage;
    public float damageRate;

    float nextDamage;

    Animator anim;
    AudioSource enemyAS;

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;

        anim = GetComponentInParent<Animator>();
        enemyAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        playerHealth playerHealth = other.gameObject.GetComponent<playerHealth>();

        if(other.tag == "Player" && nextDamage < Time.time)
        {
            if (playerHealth.healthSlider.value <= 0) return;
            playerHealth.addDamage(damage);
            anim.SetTrigger("isAttacking");
            enemyAS.PlayOneShot(hitSound);
            nextDamage = Time.time + damageRate;
        }
    }
}
