using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLeaderboard : MonoBehaviour
{
    private readonly string[] _leaderboardNames = {"King" + "\t", "Queen", "Rook" + "\t", "Knight", "Bishop", "Hunter", "Blacksmith", "Pawn" + "\t", "Farmer", "Peasant" };
    [SerializeField] private TextMeshProUGUI[] _leaderboardTextArr; //10x "Text Mesh Pro UGUI" need to be positioned and moved into this array
    [SerializeField] private Button _leaderboardButton;
    [SerializeField] private GameObject _leaderboardImage;
    private bool isLeaderboardOpen = false;
    private void Start()
    {
       // _leaderboardButton.onClick.AddListener(ToggleLeaderboard);
    }
    //Can be called when pressing a button that shows leaderboard
    public void SetLeaderboardText(float[] currentLeaderboard)
    {
        for (int i = 0; i < _leaderboardTextArr.Length; i++)
        {
            _leaderboardTextArr[i].text = (i + 1 + ".\t") + _leaderboardNames[i] + "\t"+  currentLeaderboard[i] + "";
        }
    }
   // private void ToggleLeaderboard()
   // {
     //   isLeaderboardOpen = !isLeaderboardOpen;

       // if (isLeaderboardOpen)
      //  {
       //     _leaderboardImage.SetActive(true);
       // }
       // else
      //  {
      //      _leaderboardImage.SetActive(false);
      //  }
    //}
}