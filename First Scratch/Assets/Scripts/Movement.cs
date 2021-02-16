using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour{
    /*
    private Rigidbody rb;
    private float time = 0.0f;
    private bool isMoving = false;
    private bool isJumpPressed = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isJumpPressed = Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        if (isJumpPressed)
        {
            // the cube is going to move upwards in 10 units per second
            rb.velocity = new Vector3(0, 0, 10);
            isMoving = true;
            Debug.Log("jump");
        }

        if (isMoving)
        {
            // when the cube has moved for 10 seconds, report its position
            time = time + Time.fixedDeltaTime;
            if (time > 10.0f)
            {
                Debug.Log(gameObject.transform.position.y + " : " + time);
                time = 0.0f;
            }
        }
    }
}
*/
    private Rigidbody rb;
    //public float thrust = 1.0f;
    //private bool isLeftPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    /*
    void Update(){
        float moveSpeed = 10;
        //Define the speed at which the object moves.

        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        //rb.transform.Translate(new Vector3(horizontalInput, 0, ) * moveSpeed * Time.deltaTime);
        isLeftPressed = Input.GetButtonDown("left");
        if(isLeftPressed){
        transform.position = transform.forward * moveSpeed * Time.deltaTime + transform.position;
        }
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
         }
         */

    public float speed;
    public float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
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
