using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 9;
    public float walkAcceleration = 75;
    public float airAcceleration = 30;
    public float groundDeceleration = 70;
    public float jumpHeight = 4;
    public bool isGrounded;
    public bool imColliding;




    private Vector2 velocity;

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
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(velocity * Time.deltaTime);
        }
      
      
    }
    void Pular()
    {
        if (isGrounded)
        {
            velocity.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                isGrounded= false;
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
                

            }

        }
        else
        {
            velocity.y += Physics2D.gravity.y * Time.deltaTime;
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
