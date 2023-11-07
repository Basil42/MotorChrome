using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeaderboardMenu : MonoBehaviour
{
    public GameObject Leaderboard;
    public GameObject MainMenuOptions;
    

    public void BackButton()
    {
        Leaderboard.SetActive(false);
        MainMenuOptions.SetActive(true);
    }

  
}