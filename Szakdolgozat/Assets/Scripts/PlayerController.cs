using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement variables
    public float maxSpeed;

    //Jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    //audio variables
    public AudioClip[] runningSound;
    public float runningSoundTime;
    AudioSource playerAS;
    float nextRunningSound = 0f;

    Rigidbody2D RB;
    Animator anim;

    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerAS = GetComponent<AudioSource>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the character are grounded... if no, than we - the character - is falling
        CheckGrounded();

        //Horizontal movement
        Horizontal();
        

        //Vertical movement
        Vertical();
        
        //Player attacking
        Attacking();
    }

    private void runningSounds()
    {
        AudioClip tempClip = runningSound[UnityEngine.Random.Range(0, runningSound.Length)];
        playerAS.clip = tempClip;
        playerAS.Play();
        nextRunningSound = runningSoundTime + Time.time;
    }

    private void CheckGrounded()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        anim.SetBool("isGrounded", grounded);
        anim.SetFloat("verticalSpeed", RB.velocity.y);
    }

    private void Horizontal()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
        RB.velocity = new Vector2(move * maxSpeed, RB.velocity.y);

        if ((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) 
            && grounded == true && nextRunningSound < Time.time)
            runningSounds();

        //Character facing direction
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    private void Vertical()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            anim.SetBool("isGrounded", grounded);
            RB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void Attacking()
    {
        if (Input.GetAxisRaw("Fire1") > 0) anim.SetBool("isAttacking", true);
        else anim.SetBool("isAttacking", false);
    }
}
