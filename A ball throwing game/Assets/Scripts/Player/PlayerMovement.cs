using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * From https://github.com/valgoun/CharacterController/blob/master/Assets/Scritps/RigidbodyCharacter.cs
 */

namespace Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed = 5f;
        public float JumpHeight = 2f;
        public float GroundDistance = 0.2f;
        public float DashDistance = 5f;
        public LayerMask Ground;
        public Transform groundCheck;

        private Rigidbody rb;
        private Vector3 inputs = Vector3.zero;
        public bool OnGround = true;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            OnGround = Physics.CheckSphere(groundCheck.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

            inputs = Vector3.zero;
            inputs.x = Input.GetAxis("Horizontal");
            inputs.z = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Jump") && OnGround)
            {
                rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            }
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + transform.forward * inputs.z * Speed * Time.fixedDeltaTime + transform.right * inputs.x * Speed * Time.fixedDeltaTime);
        }
    }
}