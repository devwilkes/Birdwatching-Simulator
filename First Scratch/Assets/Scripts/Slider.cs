using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomSlider : MonoBehaviour{
    /* Start is called before the first frame update
    public Slider mainSlider;

    void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
		//mainSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
	}
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log (mainSlider);
    }

    // Invoked when the value of the slider changes.
	/*
    public void ValueChangeCheck()
	{
		Debug.Log (mainSlider.value);
	}
    */
 public float scale;
    public Slider slider;
 
    void Start()
    {
        //Cache the Slider variables
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }
    void OnEnable()
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
