using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour{

var cam1 : Overworld_Camera;
var cam2 : Camera_Mode_Camera;
 
 function Start(){
     cam1.enabled = true;
     cam2.enabled = false;
 }
 
 function Update(){
 
     if (Input.GetKeyDown(KeyCode.C)) {
         cam1.enabled = !cam1.enabled;
         cam2.enabled = !cam2.enabled;
     }
 }
 
}
