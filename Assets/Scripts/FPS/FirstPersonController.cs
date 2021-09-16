using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;


    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;



   

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // cjecks if the player is on the ground, returns true or false

        if(isGrounded && velocity.y < 0) // if player is on the ground reset the velocity.
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) // if space is pressed and player is on ground
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // increases player velocity by the square root of jumpHeight * -2 * gravity.
        }

        velocity.y += gravity * Time.deltaTime; // Increases player fall speed by gravity over time.

        controller.Move(velocity * Time.deltaTime); // Constantly pushing the player to the ground

    }
}
