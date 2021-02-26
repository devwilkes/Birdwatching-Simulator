using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomSlider : MonoBehaviour{
    // Start is called before the first frame update
    //public Slider mainSlider;

    public float scale;
    public Slider slider;
 
    void Start()
    {
        //Cache the Slider variables
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }
    void OnUpdate()
    {
        //Subscribe to the Slider Click event
        slider.onValueChanged.AddListener(delegate { sliderCallBack(slider); });
    }
    //Will be called when Slider changes
    public void sliderCallBack(Slider slider)
    {
        Debug.Log("Slider Changed: " + slider.value);
        scale = slider.value;
    }

}
