using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // sets default to having the menu hidden
     public bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    

    void Update()
    {  
        Debug.Log(Input.GetKeyDown(KeyCode.Escape));
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

    public void Return_Button(){
        Debug.Log("Back in Action!");
        Resume();
    }

    public void Teleport_Button(){
        Debug.Log("Returning to base...");
    }

    public void Options_Button(){
        Debug.Log("Options");
    }

    public void Exit_Button(){
        Debug.Log("Returning to Main Menu...");
    }

    public void Desktop_Button(){
        Debug.Log("Closing Game...");
        Application.Quit();
    }

}
