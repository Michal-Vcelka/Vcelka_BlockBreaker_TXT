using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //nase premene
    [SerializeField] public string playerName = "";
    [SerializeField] public string playerScore = "";
    [SerializeField] public string playerLevel = "";

    //getter a setter kazdej premennej
    public string PlayerName { get => playerName; set => playerName = value; }
    public string PlayerScore { get => playerScore; set => playerScore = value; }
    public string PlayerLevel { get => playerLevel; set => playerLevel = value; }
    /*
    //sluzi pri LoadGame()
    public Player()
    { }

    //sluzi pri SaveGame()
    public Player(string PlayerName, string PlayerScore, string PlayerLevel)
    {
        playerName = PlayerName;
        playerScore = PlayerScore;
        playerLevel = PlayerLevel;
    }*/
}