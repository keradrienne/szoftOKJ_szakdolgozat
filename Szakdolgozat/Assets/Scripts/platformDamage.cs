using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;

    float nextDamage;

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            playerHealth playerHealth = other.gameObject.GetComponent<playerHealth>();
            playerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            playerHealth playerHealth = other.gameObject.GetComponent<playerHealth>();
            playerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;
        }
    }
}
