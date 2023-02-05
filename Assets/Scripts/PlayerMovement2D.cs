using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float speedAtual = 0f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    public AudioSource Deathsfx;

    [SerializeField] public BuddyController buddy;
    [SerializeField] public Animator animBuddy;
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


        if(speedAtual == speed)
        {
            animBuddy.SetBool("isWalking", true);
        }
        else if(speedAtual == -speed){
            
            animBuddy.SetBool("isWalking", true);
        }
        else
        {
            animBuddy.SetBool("isWalking", false);
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
            localScale.x *= - 1f;
            transform.localScale = localScale;

            
            Vector2 buddyScale = buddy.transform.localScale;
            buddyScale.x *= - 1f;
            buddy.transform.localScale = buddyScale;
        }
    }

    public void TakeDamage()
    {
        gameObject.SetActive(false);
        Deathsfx.Play();
    }
}
