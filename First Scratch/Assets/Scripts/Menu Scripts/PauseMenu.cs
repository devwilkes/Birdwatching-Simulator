using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    // sets default to having the menu hidden
     public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public Button OptionsButton;
    public Button ReturnToGame;
    public Button ExitButton;
    public Button ExitGame;
    public Button WarpButton;

    
    void Start(){
        OptionsButton.onClick.AddListener(On_Options_Button_Click);
        ReturnToGame.onClick.AddListener(On_Return_Button_Click);
        ExitGame.onClick.AddListener(On_Desktop_Button_Click);
        ExitButton.onClick.AddListener(On_Exit_Button_Click);
        WarpButton.onClick.AddListener(On_Teleport_Button_Click);
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
            } else{
                Pause();
            }
        }
    }

    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void On_Return_Button_Click(){
        Debug.Log("Back in Action!");
        Resume();
    }

    public void On_Teleport_Button_Click(){
        Debug.Log("SOS!...");
        GameManager.Instance.RespawnAtLastCheckpoint();
        Resume();
    }

    public void On_Options_Button_Click(){
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        Debug.Log("Options...");
    }

    public void On_Exit_Button_Click(){
        Debug.Log("Returning to Main Menu...");
    }

    public void On_Desktop_Button_Click(){
        Debug.Log("Closing Game...");
        Application.Quit();
    }

}
