using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float inAirSpeed = 2f;
    public float inAirVelocityReduction = 0.4f;

    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    Vector3 jumpVelocity;
    public bool Grounded { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ground check
        Grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Grounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        // Horizontal movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        
        // In air movement
        if (!Grounded) 
        {
            movement = movement * speed / inAirSpeed + jumpVelocity;
            if (x != 0 || z != 0) 
            {
                ReduceJumpVelocity();
            }
        }
        else
        {
            movement *= speed;
        }

        // The actual moving
        controller.Move(movement * Time.deltaTime);

        ReduceJumpVelocity();

        // Jumping
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            jumpVelocity = new Vector3(controller.velocity.x, 0f, controller.velocity.z);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void ReduceJumpVelocity() 
    {
        // Jumping velocity reduction
        if (jumpVelocity.x > 0.5f)
        {
            jumpVelocity.x -= inAirVelocityReduction;
        }
        else if (jumpVelocity.x < -0.5f)
        {
            jumpVelocity.x += inAirVelocityReduction;
        }

        if (jumpVelocity.z > 0.5f)
        {
            jumpVelocity.z -= inAirVelocityReduction;
        }
        else if (jumpVelocity.z < -0.5f)
        {
            jumpVelocity.z += inAirVelocityReduction;
        }
    }
}
