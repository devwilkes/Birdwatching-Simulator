using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Movement : MonoBehaviour
{
    public CharacterController controller;

    pubic float speed = 12f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
    }
}
