using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/Mouse Look")]
public class CameraMove : MonoBehaviour {
/*
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    public Transform playerBody;

    void Update ()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

        playerBody.Rotate(Vector3.up)
    }

    void Start ()
    {
    //if(!networkView.isMine)
        //enabled = false;

        // Make the rigid body not change rotation
        //if (rigidbody)
            //rigidbody.freezeRotation = true;
    }
    */

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity *Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity *Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}