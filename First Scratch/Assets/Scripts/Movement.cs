using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour{
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
        Debug.Log("debug is " + isGrounded);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        Debug.Log("hinput is " + x);
        float z = Input.GetAxis("Vertical");
        Debug.Log("zinput is " + z);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move* speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
 }
