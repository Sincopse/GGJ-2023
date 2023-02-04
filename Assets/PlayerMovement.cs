using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    Vector2 fVelocity;

    Vector2 xVelocity;
    Vector2 yVelocity;

    //speed X movement
    float xspeed = 5;
    //Variaveis do pulo
    float maxHeight = 5f;
    float jumpSpeed;
    float timeToPeak = 0.4f;

    float gravity;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = 2 * maxHeight / Mathf.Pow(timeToPeak, 2);
        jumpSpeed = gravity * timeToPeak;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        xVelocity = xspeed * xInput * Vector2.right;
        yVelocity += gravity * Time.deltaTime * Vector2.down;

        if (controller.isGrounded)
        {
            yVelocity = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            yVelocity = jumpSpeed * Vector2.up;

        }
        fVelocity = xVelocity + yVelocity;


        controller.Move(fVelocity * Time.deltaTime);
    }
}
