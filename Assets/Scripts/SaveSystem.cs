using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveSystem : MonoBehaviour
{
    string currentName = "michal";
    string currentScore = "0";
    string currentLevel = "Level_1";

    void Start()
    {
        SaveFile();
        //LoadFile();
    }

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.txt";
        FileStream file;

        Debug.Log("otvorene");
        Debug.Log(Application.persistentDataPath);

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(currentName, currentScore, currentLevel);
        StreamWriter writer = new StreamWriter(file);
        writer.WriteLine(data);
        file.Close();
    }
    /*
    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.txt";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File is missing");
            return;
        }

        StreamReader reader = new StreamReader(file);
        GameData data = (GameData)reader.ReadToEnd();
        file.Close();

        currentName = data.playerName;
        currentScore = data.playerScore;
        currentLevel = data.playerLevel;

        Debug.Log(data.playerName);
        Debug.Log(data.playerScore);
        Debug.Log(data.playerLevel);
    }
    */
}
