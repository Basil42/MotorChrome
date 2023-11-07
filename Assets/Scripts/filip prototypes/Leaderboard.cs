using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private float[] _currentLeaderboard = new float[10];
    private float _tempScoreVariable;
    private PlayerPrefsLeaderboard _leaderboardPlayerPrefs;

    private void Start()
    {
        _leaderboardPlayerPrefs = GetComponent<PlayerPrefsLeaderboard>();
        _currentLeaderboard = GetComponent<PlayerPrefsLeaderboard>().LoadData();
        SortLeaderboard(_currentLeaderboard);
        GetComponent<DisplayLeaderboard>().SetLeaderboardText(_currentLeaderboard); //Sets textelements to display leaderboard

    }

    //Check if the score is top 10, call this with current score when lose- or win condition is met
    public void IsScoreTopTen(float newScore)
    {
        _tempScoreVariable = Mathf.Round(newScore);
        for (int i = 0; i < _currentLeaderboard.Length; i++)
        {
            if (newScore > _currentLeaderboard[i])
            {
                ChangePlacings(i);
                return;
            }
        }
    }

    //Place the new score in  the correct placement and remove the current 10th place
    public void ChangePlacings(int newPlacing)
    {
        for (int i = _currentLeaderboard.Length - 1; i > newPlacing; i--)
        {
            _currentLeaderboard[i] = _currentLeaderboard[i - 1];
        }
        _currentLeaderboard[newPlacing] = _tempScoreVariable;
        _leaderboardPlayerPrefs.SaveData(_currentLeaderboard);

    }
    private float[] SortLeaderboard(float[] sortedLeadeboard)
    {
        Array.Sort(sortedLeadeboard);
        Array.Reverse(sortedLeadeboard);
        return sortedLeadeboard;
    }
}
