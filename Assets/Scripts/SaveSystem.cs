using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] string currentName = "";
    [SerializeField] string currentScore = "";
    [SerializeField] string currentLevel = "";
    //v kode maju pridane [SerializeField] skrz ktoré som kontroloval funkcnost

    /*void Start()
    {
        SaveFile();
        LoadFile();
    }*/

    public void SaveFile()
    {
        //destination je nasa cesta k txt suboru, v mojom pripade == C:\Users\micha\AppData\LocalLow\DefaultCompany\BlockBreaker
        string destination = Application.persistentDataPath + "/save.txt";
        FileStream file;
        //otvorenie existujuceho suboru, ak doteraz neexistoval tak sa vytvori
        if (File.Exists(destination)) file = File.OpenWrite(destination);
       
        else file = File.Create(destination);

        //prepojenie na Player.cs, zapisujeme data ktore su momentalne aktualne v Player
        //Player data = new Player(currentName, currentScore, currentLevel);
        currentName = player.PlayerName;
        currentScore = player.PlayerScore;
        currentLevel = player.PlayerLevel;
        //otvorenie StreamWriteru a napojenie na subor vyssie
        StreamWriter writer = new StreamWriter(file);
        //zapis dat do suboru s odsekmi - 1 udaj = 1 riadok
        writer.WriteLine(currentName + "\n" + currentScore + "\n" + currentLevel);
        //zatvorenie streamWriteru
        writer.Close();

        //kontrolny vypis ukladanych udajov do konzoly
        Debug.Log("ulozene meno je " + currentName);
        Debug.Log("ulozene skore je " + currentScore);
        Debug.Log("ulozeny level je " + currentLevel);
        
        file.Close();
        //súbor treba zavriet
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.txt";
        FileStream file;

        //otvorenie suboru, a osetrenie pre pripad, ze súbor tam neni
        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File is missing");
            return;
        }

        StreamReader reader = new StreamReader(file);

        // GameData data = (GameData)reader.ReadToEnd();
        //precitanie novych dat a ich zapis do hry
        player.PlayerName = reader.ReadLine();
        player.PlayerScore = reader.ReadLine();
        player.PlayerLevel = reader.ReadLine();
        //nastavenie novych dat
        currentName = player.PlayerName;
        currentScore = player.PlayerScore;
        currentLevel = player.PlayerLevel;
        //kontrolny vypis
        Debug.Log(player.PlayerName);
        Debug.Log(player.PlayerScore);
        Debug.Log(player.PlayerLevel);
        //zatvorenie a ukoncenie
        reader.Close();
        file.Close();

    }

}

