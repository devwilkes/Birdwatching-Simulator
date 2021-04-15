using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
 public Vector3 home; // = (19.27, 17.04, 20.09);
    Vector3 warpPosition = Vector3.zero;
    void fixHome()
    {
        home = transform.position;
    }

    public void WarpToHome()
    {
        warpPosition = home;
    }
    
    void LateUpdate()
    {
        if (warpPosition != Vector3.zero)
        {
                transform.position = warpPosition;
                warpPosition = Vector3.zero;
        }
    }

    void ButtonWarp(){
        WarpToHome();
        LateUpdate();
    }
}
