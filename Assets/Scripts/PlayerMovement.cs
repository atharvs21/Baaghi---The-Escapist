using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    //bool shoot = false;
    float horizontalMove = 0f;
    public bool grounded;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            grounded = false;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        /*if(Input.GetButtonDown("Fire1"))
        {
            shoot = true;
            animator.SetBool("IsShooting", true);
        }*/
        
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isDucking)
    {
        animator.SetBool("IsDucking", isDucking);
    }
    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch , jump);
        jump = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public bool canAttack()
    {
        return grounded && Input.GetAxis("Horizontal") == 0;
    }
}

