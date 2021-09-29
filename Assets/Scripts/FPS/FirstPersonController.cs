using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstPersonController : MonoBehaviour
{
    
    public CharacterController controller;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Transform cam;


    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Animator animator;

    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        if(OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // cjecks if the player is on the ground, returns true or false

        if(isGrounded && velocity.y < 0) // if player is on the ground reset the velocity.
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        

        //Vector3 move = transform.right * horizontal + transform.forward * vertical;
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        animator.SetFloat("Speed", direction.magnitude);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        

        if(Input.GetButtonDown("Jump") && isGrounded) // if space is pressed and player is on ground
        {
            
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);// increases player velocity by the square root of jumpHeight * -2 * gravity.
              
            
        }
        

        if(isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }
        else { OnLanding(); }


        velocity.y += gravity * Time.deltaTime; // Increases player fall speed by gravity over time.

        controller.Move(velocity * Time.deltaTime); // Constantly pushing the player to the ground

    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
}
