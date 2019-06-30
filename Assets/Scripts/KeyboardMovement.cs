using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{

    public float movement;

    public float jumpVelocity = 3f;

    public float speed = 1.3f;

    bool isCrouch = false;

    bool isAir = false;

    bool isManaEmpty = false;

    public Animator animator;

    public LowShield shieldControll;

    public ManaBar manabar;

    SpriteRenderer SR;

    Rigidbody2D rB2D;


    // Use this for initialization
    void Start()
    {
        shieldControll = GetComponentInChildren<LowShield>();

        SR = GetComponent<SpriteRenderer>();

        rB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        shieldControll = GetComponentInChildren<LowShield>();

        Movement();

        Animation();
    }

    void Movement()
    {
        this.transform.position += new Vector3(movement * speed * Time.deltaTime, 0, 0);

        if (isCrouch == true)
        {
            movement = 0;
            jumpVelocity = 0;
        }
        else
        {
            jumpVelocity = 2.9f;
        }

        //skok
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rB2D.velocity.y == 0)
            {
                rB2D.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }

        //kucanie
        if (Input.GetKey(KeyCode.S))
        {
            if (isManaEmpty == true)
            {
                speed = 1.3f;
                isCrouch = false;
                shieldControll.Disable();
                return;
            }
            if (isAir == true) { return; }
            manabar.ShieldWhenS();
            speed = 0;
            isCrouch = true;
            shieldControll.Enable();
            if (manabar.mana.manaAmount <= 2)
            {
                isManaEmpty = true;
            }
            return;
        }
        else
        {
            if (manabar.mana.manaAmount >= 2)
            {
                isManaEmpty = false;
            }
            speed = 1.3f;
            isCrouch = false;
            shieldControll.Disable();
        }

        Debug.Log(movement);

        
    }

    //------------------skrypt do animowania postaci------------------
    void Animation()
    {
        if (movement > 0)
        {
            SR.flipX = false;
        }
        else if(movement < 0)
            SR.flipX = true;

        //Tutaj jest animacja skosku

        if (rB2D.velocity.y > 0.1f)
        {
            animator.SetBool("IsJump", true);
            isAir = true;
        }
        else if (rB2D.velocity.y < -0.1f)
        {
            animator.SetBool("IsFall", true);
            animator.SetBool("IsJump", false);
            isAir = true;
        }
        else if (rB2D.velocity.y == 0)
        {
            animator.SetBool("IsFall", false);
            animator.SetBool("IsJump", false);
            isAir = false;
        }

        // animacja kucania

        if (Input.GetKey(KeyCode.S))
        {
            if (isManaEmpty == true)
            {
                animator.SetBool("IsCrouch", false);
                return;
            }
            if (isAir == true) { return; }
            animator.SetBool("IsCrouch", true);
            animator.SetFloat("Speed", 0);
            return;
        }
        else
        {
            if (manabar.mana.manaAmount >= 50)
            {
                isManaEmpty = false;
            }
            animator.SetBool("IsCrouch", false);
        }

        animator.SetFloat("Speed", Mathf.Abs(movement));
    }


    public void Jump()
    {
        if (rB2D.velocity.y == 0)
        {
            rB2D.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
        }
    }
}