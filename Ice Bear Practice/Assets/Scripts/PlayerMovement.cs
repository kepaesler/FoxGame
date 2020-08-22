using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runspeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;



    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            Debug.Log("jump");
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

    void FixedUpdate()
    {
        // move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
