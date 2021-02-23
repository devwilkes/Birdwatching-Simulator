using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour{
   
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

 }
