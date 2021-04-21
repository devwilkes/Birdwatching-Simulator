using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenuUI;
    public GameObject pauseMenuUI;
    public Button BackButton;

    public 
    void Start()
    {
        BackButton.onClick.AddListener(On_Return_Button_Click);
        optionsMenuUI.SetActive(false);
    }

    void Update()
    {
        
        
    }

    public void On_Return_Button_Click(){
    optionsMenuUI.SetActive(false);
    pauseMenuUI.SetActive(true);
    }
}
