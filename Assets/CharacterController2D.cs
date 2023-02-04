using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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




    public Vector2 velocity;
   

    void Start()
    {
   
       
    }

    // Update is called once per frame
    void Update()
    {
        Movimento(); 
        Pular();

    }
    void Movimento()
    {
        transform.Translate(velocity * Time.deltaTime);
    
        float moveInput = Input.GetAxisRaw("Horizontal");

        float acceleration = isGrounded ? walkAcceleration : airAcceleration;
        float deceleration = isGrounded ? groundDeceleration : 0;

        if(!imColliding)
        {
            if (moveInput != 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
                if(velocity.x > 0)
                {
                    airHeight = (velocity.x/2);
                }
                else
                {
                    airHeight = -(velocity.x/2);
                }
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
                if (isGrounded)
                {
                    airHeight = 0;
                }
                
            }
        }
        else
        {
            transform.Translate(velocity * Time.deltaTime);
        }
      
      
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
                velocity.y = Mathf.Sqrt(2 * jumpheight * Mathf.Abs(Physics2D.gravity.y));
                

            }

        }

        else if (velocity.y == jumpheight)
        {
            
            velocity.y = Physics2D.gravity.y * Time.deltaTime;
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
            isGrounded = true;
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
            isGrounded = false;
            imColliding = false;
            print("sai no obstaculo");
        }
    }
    
 
}
