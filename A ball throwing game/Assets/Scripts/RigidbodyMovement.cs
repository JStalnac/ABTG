using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public float speed = 400f;
    public bool Grounded { get; set; }
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.AddRelativeForce(x * speed * Time.deltaTime, 0f, z * speed * Time.deltaTime);
    }
}
