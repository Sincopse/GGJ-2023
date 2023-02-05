using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float horizontal;
    public float speed = 8f;
    public float speedAtual = 0f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    Animator animator;

    [SerializeField] public BuddyController buddy;
    [SerializeField] public Animator buddyA;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask collisionLayer;


    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        

        //movimento pulo
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }
    private void FixedUpdate()
    {
  
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        speedAtual = horizontal * speed;
        
        if(speedAtual == speed || speedAtual == -speed)
        {
            
            buddyA.SetBool("isWalking", true);
        }
        else
        {
            buddyA.SetBool("isWalking", false);
        }
          
    }
    private bool IsGrounded()
    {
        print("ESTOU NO CHÂO");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, collisionLayer);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight;


            Vector2 localScale = transform.localScale;
            Vector2 buddyScale = buddy.transform.localScale;
            localScale.x *= - 1f;
            buddyScale.x *= - 1f;

            buddy.transform.localScale = buddyScale;
            transform.localScale = localScale;
        }
    }

    
}
