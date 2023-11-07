using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject MainMenuOptions;
    public GameObject Leaderboard;
    public InputAction startPress, quitpress, leaderboardPress,settingPress;
    private bool isOpen = false;
    

    private void Awake()
    {
        settingPress.performed += openOptionsMenu;
        leaderboardPress.performed += openLeaderboard;
        startPress.performed += PlayGame;
        quitpress.performed += QuitGame;
        startPress.Enable();
        quitpress.Enable();
        leaderboardPress.Enable();
        settingPress.Enable();
    }

    private void OnDestroy()
    {
        startPress.performed -= PlayGame;
        quitpress.performed -= QuitGame;
        startPress.Disable();
        quitpress.Disable();
        leaderboardPress.performed -= openLeaderboard;
        leaderboardPress.Disable();
        settingPress.performed -= openOptionsMenu;
        settingPress.Disable();
    }
    
    public void PlayGame(InputAction.CallbackContext callbackContext)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        startPress.Disable();
        quitpress.Disable();
    }

    public void PlayGameMouse()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        startPress.Disable();
        quitpress.Disable();
    }


    public void openLeaderboard(InputAction.CallbackContext callbackContext)
    {
        if (isOpen == false)
        {
            isOpen = true;
            Leaderboard.SetActive(true);
            MainMenuOptions.SetActive(false); 
        }
        else
        {  isOpen = false;
           Leaderboard.SetActive(false);
           MainMenuOptions.SetActive(true);

        }
        
        
    }
    public void openOptionsMenu(InputAction.CallbackContext callbackContext)
    {
        if (isOpen == false)
        {
            isOpen = true;
            optionsMenu.SetActive(true);
            MainMenuOptions.SetActive(false); 
        }
        else
        {  isOpen = false;
            optionsMenu.SetActive(false);
            MainMenuOptions.SetActive(true);

        }
        
        
    }
    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        MainMenuOptions.SetActive(false);
        
    }

    public void openLeaderboardmouse()
    {
        Leaderboard.SetActive(true);
        MainMenuOptions.SetActive(false);
    }
    public void QuitGame(InputAction.CallbackContext callbackContext)
    {
        Application.Quit();
    }

    public void QuitGameMouse()
    {
        Application.Quit();
    }
}
