using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D RB;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange && distToPlayer > 1.3f)
        {
            chasePlayer();
        }
        else
        {
            stopChasingPlayer();
        }
    }

    void stopChasingPlayer()
    {
        RB.velocity = Vector2.zero;
        anim.SetBool("isCharging", false);
    }

    void chasePlayer()
    {
        if(transform.position.x < player.transform.position.x)
        {
            RB.velocity = new Vector2(moveSpeed, 0);
            anim.SetBool("isCharging", true);
            transform.localScale = new Vector2(-0.3f, 0.3f);
        }
        else
        {
            RB.velocity = new Vector2(-moveSpeed, 0);
            anim.SetBool("isCharging", true);
            transform.localScale = new Vector2(0.3f, 0.3f);
        }
    }
}
