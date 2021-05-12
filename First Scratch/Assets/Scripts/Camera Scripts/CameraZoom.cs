using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    public float minFov = 15f;
    public float maxFov = 90f;

    private float fovRange;
    public float sensitivty = 10f;
    public Camera mainCam;

    private Component zoomComponent;

    private Slider zoomSlider;

     void Start()
    {
         fovRange = maxFov - minFov;
         Debug.Log(GameObject.Find("First Person Hud") + "is here!");
         zoomSlider = GameObject.Find("Zoom Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update(){
        if(mainCam == null){
            return;
        }

        float fov = mainCam.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel")* sensitivty;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        if(mainCam.fieldOfView != fov){
            mainCam.fieldOfView = fov;
            float sliderValue = (fov - minFov)/fovRange;
            zoomSlider.SetValueWithoutNotify(sliderValue);
        }
    }

}
