using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivty = 10f;
    public Camera mainCam;

    /* Start is called before the first frame update
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update(){
        if(mainCam == null){
            return;
        }

        float fov = mainCam.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel")* sensitivty;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        mainCam.fieldOfView = fov;
    }

    void sliderInput(){
        
    }
}
