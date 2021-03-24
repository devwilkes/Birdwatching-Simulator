using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeToggle : MonoBehaviour{

public Camera cam1;
public Camera cam2;
public Script moveScript1;
public Script moveScript2;
 
 void Start(){
     cam1.enabled = false;
     cam2.enabled = true;
     moveScript1 = GetComponent<FP_Movement>();
     moveScript2 = GetComponent<TP_Movement>();
     movescript1.enabled = false;
     movescript2.enabled = true;
 }
 
 void Update(){
 
     if (Input.GetButtonDown("Fire2")) {
         cam1.enabled = !cam1.enabled;
         moveScript1.enabled = !moveScript1.enabled;
         cam2.enabled = !cam2.enabled;
         moveScript2.enabled = !movescript2.enabled;
     }
 }

}