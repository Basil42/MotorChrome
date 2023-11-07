using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    public InputAction menuPress,quitPress,MainMenuPress;
    [SerializeField] private Scoring playerScoring;

    public void Awake()
    {
        menuPress.Enable();
        menuPress.performed += Pause;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        quitPress.Disable();
        MainMenuPress.Disable();
        Debug.Log("is not paused");
    }
    void Pause(InputAction.CallbackContext callbackContext)
    {
        TogglePause();
        Debug.Log(Time.timeScale);
    }

    void TogglePause()
    {
        IsPaused = !IsPaused;
        if (IsPaused)
        {
            quitPress.Enable();
            MainMenuPress.Enable();
            quitPress.performed += quitMenuGamepad;
            MainMenuPress.performed += LoadMenuGamepad;
            Time.timeScale = 0f;
            PauseMenuUI.SetActive(true);
            Debug.Log("is paused");
            
            
        }
        else
        {
            Time.timeScale = 1f;
            PauseMenuUI.SetActive(false);
            quitPress.Disable();
            MainMenuPress.Disable();
            Debug.Log("is not paused");
        }
    }

    public void LoadMenuGamepad(InputAction.CallbackContext callbackContext)
    {
        playerScoring.SubmitScore();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        MainMenuPress.Disable();
        quitPress.Disable();
        menuPress.Disable();

    }

    public void quitMenuGamepad(InputAction.CallbackContext callbackContext)
    {
        Application.Quit();
        Debug.Log("YouQuit");
        
        
    }
    public void LoadMenu()
    {
        playerScoring.SubmitScore();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
        MainMenuPress.Disable();
        quitPress.Disable();
        menuPress.Disable();
        
        
    }
    public void QuitGame()
    {
        Debug.Log("Quiting menu...");
        Application.Quit();
        
    }
}