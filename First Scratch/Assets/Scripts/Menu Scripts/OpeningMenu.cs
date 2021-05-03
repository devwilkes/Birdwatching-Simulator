using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject saveMenuUI;
    public Button StartButton;
    void Start()
    {
        StartButton.onClick.AddListener(On_Start_Button_Click);
        saveMenuUI.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void On_Start_Button_Click(){
        mainMenuUI.SetActive(false);
        saveMenuUI.SetActive(true);
        Debug.Log("Start Game!");
    }
}
