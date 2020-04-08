using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{
    public AudioClip hitSound;

    public float weaponDamage;

    Collider2D attackRange;
    AudioSource playerAS;

    // Start is called before the first frame update
    void Start()
    {
        attackRange = GetComponent<Collider2D>();
        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
            attackRange.enabled = true;
        else
            attackRange.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
            hurtEnemy.AddDamage(weaponDamage);

            playerAS.PlayOneShot(hitSound);
        }
    }
}
