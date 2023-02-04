using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterController2D : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 9;
    public float walkAcceleration = 8;
    public float airAcceleration = 10;
    public float groundDeceleration = 100; 
    public float airHeight = 9;
    public float jumpHeight = 5;
    public bool isGrounded;
    public bool imColliding;
    Rigidbody2D rb;





    public Vector2 velocity;
   

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movimento(); 
        Pular();

    }
    void Movimento()
    {
       
    
        float moveInput = Input.GetAxisRaw("Horizontal");

        float acceleration = isGrounded ? walkAcceleration : airAcceleration;
        float deceleration = isGrounded ? groundDeceleration : 0;

  
            if (moveInput != 0)
                        {
                            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.fixedDeltaTime);

                            if(velocity.x > 0)
                            {
                                airHeight = (velocity.x/4);
                            }
                            else
                            {
                                airHeight = -(velocity.x/4);
                            }
                        }
                        else
                        {
                            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.fixedDeltaTime);
                            if (isGrounded)
                            {
                                airHeight = 0;
                            }
                
                        }
        
    
        rb.MovePosition(rb.position + velocity);
     






    }
    void Pular()
    {
        float jumpheight = jumpHeight - airHeight;
        if (isGrounded)
        {
            velocity.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                isGrounded = false;
                rb.AddForce(Vector2.up * jumpheight, ForceMode2D.Force);
                //velocity.y = Mathf.Sqrt(2 * jumpheight * Mathf.Abs(Physics2D.gravity.y));
                

            }

        }

        else
        {
            
            //velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            isGrounded = true;
            print("bati no chao");
        }
        if (collision.gameObject.tag == "obstaculo")
        {
            imColliding = true;
            print("bati no obstaculo");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            isGrounded = false;
            print("sai no chao");
        }
        if (collision.gameObject.tag == "obstaculo")
        {
            imColliding = false;
            print("sai no obstaculo");
        }
    }
   

}
