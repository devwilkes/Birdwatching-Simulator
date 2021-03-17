using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeToggle : MonoBehaviour{

public Camera cam1;
public Camera cam2;
 
 void Start(){
     GameObject GOCam;

     GOCam = GameObject.Find("Overworld_Camera");
     cam1 = GOCam.GetComponent<Camera>();

     GOCam = GameObject.Find("Camera_Mode_Camera");
     cam2 = GOCam.GetComponent<Camera>();

     cam1.enabled = true;
     cam2.enabled = false;
 }
 
 void Update(){
 
     if (Input.GetKeyDown(KeyCode.C)) {
         cam1.enabled = !cam1.enabled;
         cam2.enabled = !cam2.enabled;
     }
 }

}