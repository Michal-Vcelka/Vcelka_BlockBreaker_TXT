using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    GameStatus gameStatus;
    SceneLoader sceneLoader;
    [SerializeField] SaveSystem saveSystem;
    [SerializeField] Player player;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //ak sa 
        {
            if (isGamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Debug.Log("pauza_resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = FindObjectOfType<GameStatus>().GetGameSpeed();
        isGamePaused = false;
    }
    private void Pause()
    {
        Debug.Log("pauza_pauza");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        //FindObjectOfType<GameStatus>().setSpeed(0);
        isGamePaused = true;
    }
    public void SaveData()
    {
        Debug.Log("pauza_save");
        saveSystem.SaveFile();
    }

    public void LoadData()
    {
        Debug.Log("pauza_load");
        saveSystem.LoadFile();
        SceneManager.LoadScene(player.playerLevel);
        FindObjectOfType<GameStatus>().AddToScore();
    }

}
