﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runspeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    bool balloon = false;

    //cutscene
    [SerializeField]
    private PlayableDirector director;

    public bool stop = false;

    // Update is called once per frame
    void Update()
    {
        if (director.state == PlayState.Playing)
        {
            return;
        }
        else if (stop)
        {
            horizontalMove = 0;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            crouch = false;
            jump = false;
            return;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            Debug.Log("jump");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            balloon = true;
            Debug.Log("balloon");
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log("CROUCH");
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            Debug.Log("NOT CROUCH");
        }
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("JumpAttack", false);
        Debug.Log("landed");
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    public void onBalloon()
    {
        animator.SetBool("Floating", true);
    }

    public void onBalloonEmpty()
    {
        animator.SetBool("Floating", false);
    }

    void FixedUpdate()
    {
        // move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, balloon);
        jump = false;
        balloon = false;
    }
}
