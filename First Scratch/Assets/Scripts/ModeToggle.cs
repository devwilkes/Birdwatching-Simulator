using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeToggle : MonoBehaviour{

    public Camera cam1;
    public Camera cam2;

    public GameObject fpControlsUI;
    public GameObject tpControlsUI;
    
    void Start(){
        cam1.enabled = true;
        cam2.enabled = false;
        GetComponent<FP_Movement>().enabled = true;
        GetComponent<TP_Movement>().enabled = false;
        fpControlsUI = GameObject.FindGameObjectWithTag("IGFPUI");
        tpControlsUI = GameObject.FindGameObjectWithTag("IGTPUI");
        fpControlsUI.SetActive(false);
        tpControlsUI.SetActive(true);
    }
    
    void Update(){
        if (Input.GetButtonDown("Fire2")) {
            cam1.enabled = !cam1.enabled;
            GetComponent<FP_Movement>().enabled = !cam1.enabled;
            tpControlsUI.SetActive(cam1.enabled);
            cam2.enabled = !cam2.enabled;
            GetComponent<TP_Movement>().enabled = !cam2.enabled;
            fpControlsUI.SetActive(cam2.enabled);
            
        }
    }

}