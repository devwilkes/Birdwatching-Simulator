using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FP_Movement : MonoBehaviour{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool runPress = false;

    void Update(){

        if (Input.GetButtonDown("Fire1")){
            runPress = !runPress;
        }

        if(runPress == true){
            speed = 25f;
        }
        else{
            speed = 12f;
        }

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
