using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class GameOver : MonoBehaviour
{
    public InputAction startPress, quitpress;
    private void Awake()
    {
        startPress.performed += MainMenu;
        quitpress.performed += QuitGame;
        startPress.Enable();
        quitpress.Enable();
    }
    private void OnDestroy()
    {
        startPress.performed -= MainMenu;
        quitpress.performed -= QuitGame;
        startPress.Disable();
        quitpress.Disable();
    }
    public void MainMenu(InputAction.CallbackContext callbackContext)
    {
        SceneManager.LoadScene("MainMenu");
        startPress.Disable();
        quitpress.Disable();
    }

    public void MainMenuMouse()
    {
        SceneManager.LoadScene("MainMenu");
        startPress.Disable();
        quitpress.Disable();
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

