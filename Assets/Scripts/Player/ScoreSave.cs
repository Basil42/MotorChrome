using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this on the player
public class ScoreSave : MonoBehaviour
{
    private Scoring _scoring;
    
    public void SaveScore()
    {
        //call this when the game ends.
        _scoring = GetComponent<Scoring>();
        PlayerPrefs.SetInt("Latest Score", (int)Mathf.Round(_scoring.CurrentScore));
    }
}