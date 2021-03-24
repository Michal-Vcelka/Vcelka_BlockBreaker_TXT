using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    public string playerName;
    public string playerScore;
    public string playerLevel;

    public GameData(string PlayerName, string PlayerScore, string PlayerLevel)
    {
        playerName = PlayerName;
        Convert.ToInt32(PlayerScore);
        playerScore = PlayerScore;
        playerLevel = PlayerLevel;
    }
}
