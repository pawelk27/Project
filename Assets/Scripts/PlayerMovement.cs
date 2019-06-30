﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float movement;

    Rigidbody2D rB2D;

    public float jumpVelocity = 3f;

    public float speed = 1.3f;

    bool isCrouch = false;

    bool isAir = false;

    bool isManaEmpty = false;

    bool isCrouchPressed = false;

    public Animator animator;

    public ShieldControll shieldControll;

    public ManaBar manabar;

    //public Joystick joystick;
    
    //SpriteRenderer SR;


	// Use this for initialization
	void Start () {

        //SR = GetComponent<SpriteRenderer>();

        rB2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        Movement();

        Animation();
        
    }

    //do testów
    public void FullMana()
    {
        manabar.mana.manaAmount = 100;
        isManaEmpty = false;
    }





    //------------------ Służy do obliczeń itp odnośnie controlera postaci------------------
    void Movement()
    {
        if (isCrouch == true)
        {
            movement = 0;
            jumpVelocity = 0;
        }
        else
        {
            jumpVelocity = 2.9f;
        }


        //joystick !!!!!!
        /*

        if (joystick.Horizontal >= .2f)
        {
            movement = speed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            movement = -speed;
        }
        else
        {
            movement = 0;
        }

        if (movement > 0)
        {
            SR.flipX = false;

        }
        else if (movement < 0)
        {
            SR.flipX = true;
        }
        */

        //skok
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rB2D.velocity.y == 0)
            {
                rB2D.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }

        //kucanie
        if (isCrouchPressed==true || Input.GetKey(KeyCode.S))
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
        
        this.transform.position += new Vector3(movement * Time.deltaTime, 0, 0);
    }

    //------------------skrypt do animowania postaci------------------
    void Animation()
    {
        
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

        if (isCrouchPressed == true || Input.GetKey(KeyCode.S))
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

    public void CrouchDown()
    {
        isCrouchPressed = true;
    }

    public void CrouchUp()
    {
        isCrouchPressed = false;
    }
}