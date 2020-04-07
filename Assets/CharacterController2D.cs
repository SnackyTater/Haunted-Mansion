using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] Transform GroundCheck;


    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    bool isGrounded;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //Ground Check
        if (Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        //Horizontal Movement
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (isGrounded)
            {
                spriteRenderer.flipX = true;
                animator.Play("Player_run");
            }
            else if (!isGrounded)
            {
                spriteRenderer.flipX = true;
                animator.Play("Player_jump");
            }
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (isGrounded)
            {
                spriteRenderer.flipX = false;
                animator.Play("Player_run");
            }
            else if (!isGrounded)
            {
                spriteRenderer.flipX = false;
                animator.Play("Player_jump");
            }

        }
        else
        {
            if(isGrounded) // cham dat thi play idle animation
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                animator.Play("Player_idle");
            }
            else if (!isGrounded) // neu khong cham dat thi play jump animation
            {
                animator.Play("Player_jump");
            }
          
        }
       
        //Jumping
        if ((Input.GetKey("w") || Input.GetKey("up")) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Slide
        
       
    }
   
}
