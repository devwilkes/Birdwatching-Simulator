using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour{
   /*
    private Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();

    }

    public float speed;
    public float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;

    // Update is called once per frame
    void FixedUpdate(){
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // get the user's vertical input
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        rb.transform.Translate(Vector3.forward * speed * verticalInput);
        rb.transform.Translate(Vector3.right * speed * horizontalInput);
        // tilt the plane up/down based on up/down arrow keys
        //rb.transform.Rotate(Vector3.right, horizontalInput * rotationSpeed * Time.deltaTime);
    }
    */

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Update(){

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move* speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



    }
 }
