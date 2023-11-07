using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsLeaderboard : MonoBehaviour
{
    private float[] leaderboardToLoad = new float[10];
    public void SaveData(float[] leaderboardToSave)
    {
        for (int i = 0; i < leaderboardToSave.Length; i++)
        {
            PlayerPrefs.SetFloat(i + "", leaderboardToSave[i]);
        }
    }
    public float[] LoadData()
    {
        //float[] leaderboardToLoad = new float[10];
        for (int i = 0; i < leaderboardToLoad.Length; i++)
        {
            leaderboardToLoad[i] = PlayerPrefs.GetFloat(i + "");
        }
        return leaderboardToLoad;
    }
}
